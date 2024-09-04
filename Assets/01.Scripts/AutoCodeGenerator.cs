using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using UnityEditor;

public class AutoCodeGenerator
{
    // 프리팹이 저장된 디렉토리 경로
    // 이 경로의 프리팹을 기반으로 코드 생성
    private const string PrefabDirectory = "Assets/Prefabs/CustomUI";


    // 자동 생성된 코드가 저장될 스크립트 파일 경로
    // 이 파일이 존재하지 않을 경우 기본 파일 생성
    private const string ScriptFilePath = "Assets/Editor/CustomUIRegister.cs";



    // Unity Editor 메뉴에 "Assets/Refresh_CustomUIPrefab" 항목 추가
    // 이 함수는 프리팹 폴더를 스캔하여 새 프리팹에 대한 메뉴 항목 생성
    // 또는 삭제된 프리팹에 대한 기존 메뉴 항목을 제거하는 역할
    [MenuItem("Assets/Refresh_CustomUIPrefab", false, 1)]
    public static void Refresh_CustomUIPrefab()
    {
        // 스크립트 파일이 존재하지 않으면 기본 스크립트 파일을 생성
        if (!File.Exists(ScriptFilePath))
        {
            CreateDefaultScriptFile();
        }
        var currentPrefabFiles = GetPrefabFilesInDirectory();

        
        var savedPrefabs = CustomUIData.LoadSavedPrefabInfo();

        string scriptCode = GenerateScriptCode(currentPrefabFiles);

        // 생성된 코드를 스크립트 파일에 저장 및 Unity 에디터 갱신
        File.WriteAllText(ScriptFilePath, scriptCode);
        AssetDatabase.Refresh();

        RemoveObsoleteCode(currentPrefabFiles, savedPrefabs);

        CustomUIData.SavePrefabInfo(currentPrefabFiles);
    }



    // 지정된 디렉토리에서 모든 프리팹 파일을 검색하여 파일 이름 목록 반환
    // 반환된 목록은 스크립트 생성 및 갱신
    private static List<string> GetPrefabFilesInDirectory()
    {
        // 지정된 디렉토리에서 모든 .prefab 파일을 찾습니다.
        string[] prefabFiles = Directory.GetFiles(PrefabDirectory, "*.prefab", SearchOption.TopDirectoryOnly);

        // 파일 경로에서 파일 이름만 추출하고 확장자를 제거한 후 리스트에 추가합니다
        List<string> prefabFileNames = prefabFiles
            .Select(filePath => Path.GetFileNameWithoutExtension(filePath))
            .ToList();

        return prefabFileNames;
    }

    // 스크립트 파일이 존재하지 않을 경우 기본 스크립트 파일 생성
    // 기본 스크립트는 CustomUIRegister 클래스를 포함하며, 코드 생성 및 제거 시 사용
    private static void CreateDefaultScriptFile()
    {
        // 기본 스크립트 템플릿.
        // 이 템플릿은 프리팹 파일이 추가되거나 제거될 때 채워짐
        string defaultScript = @"
        using UnityEditor;
        
        public class CustomUIRegister
        {

        }";

        // 지정된 경로에 디렉토리가 없으면 생성
        Directory.CreateDirectory(Path.GetDirectoryName(ScriptFilePath));
        // 기본 스크립트를 스크립트 파일에 저장
        File.WriteAllText(ScriptFilePath, defaultScript.Trim());
    }

    // 주어진 프리팹 파일 목록을 기반으로 Unity 메뉴 항목을 추가하는 코드 생성
    // 각 프리팹 파일에 대해 [MenuItem] 어트리뷰트와 생성 함수 추가
    private static string GenerateScriptCode(List<string> prefabFiles)
    {
        StringBuilder sb = new StringBuilder();

        sb.AppendLine("using UnityEditor;");
        sb.AppendLine();
        sb.AppendLine("public class CustomUIRegister");
        sb.AppendLine("{");

        // 프리팹 파일 목록을 순회하며 코드에 메뉴 항목과 함수 생성
        foreach (var filename in prefabFiles)
        {
            sb.AppendLine($@"[MenuItem(""GameObject/Custom UI/{filename}"", false, 1)]");
            sb.AppendLine($@"public static void Generate_{filename.Replace(" ", "_")}() => CustomUIPrefabSystem.CreateCustomUIPrefab(""{filename}"");");
        }

        sb.AppendLine("}");

        // 생성된 코드 문자열 반환
        return sb.ToString().Trim();
    }

    // 스크립트 파일에서 현재 디렉토리에 존재하지 않는 프리팹에 대한 코드 제거
    private static void RemoveObsoleteCode(List<string> currentPrefabs, List<string> savedPrefabs)
    {
        // 스크립트 파일이 존재하지 않으면 종료
        if (!File.Exists(ScriptFilePath))
        {
            return;
        }

        // 스크립트 파일의 모든 라인 가져오기
        string[] scriptLines = File.ReadAllLines(ScriptFilePath);
        StringBuilder sb = new StringBuilder();
        bool insideCodeBlock = false;

        // 각 라인을 검사하여 불필요한 코드 제거
        foreach (var line in scriptLines)
        {
            // [MenuItem]으로 시작하는 라인을 찾고, 현재 프리팹 목록에 해당 프리팹이 없는 경우 블록 시작
            if (line.Contains("[MenuItem(\"GameObject/Custom UI/") && !currentPrefabs.Any(p => line.Contains(p)))
            {
                insideCodeBlock = true;
            }

            // 코드 블록에 포함되지 않는 라인만 StringBuilder에 추가
            if (!insideCodeBlock)
            {
                sb.AppendLine(line);
            }

            // 코드 블록의 끝을 만나면 블록 종료
            if (insideCodeBlock && line.Trim().EndsWith(");"))
            {
                insideCodeBlock = false;
            }
        }

        // 수정된 내용을 스크립트 파일에 다시 저장
        File.WriteAllText(ScriptFilePath, sb.ToString());
    }
}