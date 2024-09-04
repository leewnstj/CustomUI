using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using UnityEditor;

public class AutoCodeGenerator
{
    private const string PrefabDirectory    = "Assets/Prefabs/CustomUI";
    private const string ScriptFilePath     = "Assets/Editor/CustomUIRegister.cs";

    [MenuItem("Assets/Refresh_CustomUIPrefab", false, 1)]
    public static void Refresh_CustomUIPrefab()
    {
        if (!File.Exists(ScriptFilePath))
        {
            CreateDefaultScriptFile();
        }

        // 현재 폴더에 있는 프리팹 목록을 가져온다
        var currentPrefabFiles = GetPrefabFilesInDirectory();
        var savedPrefabs = CustomUIData.LoadSavedPrefabInfo();

        // 새로 생성할 코드
        string scriptCode = GenerateScriptCode(currentPrefabFiles);

        // 스크립트 파일 저장 및 갱신
        File.WriteAllText(ScriptFilePath, scriptCode);
        AssetDatabase.Refresh();

        // 현재 폴더에 없는 프리팹을 삭제
        RemoveObsoleteCode(currentPrefabFiles, savedPrefabs);
        CustomUIData.SavePrefabInfo(currentPrefabFiles);
    }

    private static List<string> GetPrefabFilesInDirectory()
    {
        // PrefabDirectory의 모든 프리팹 파일을 찾는다
        string[] prefabFiles = Directory.GetFiles(PrefabDirectory, "*.prefab", SearchOption.TopDirectoryOnly);

        // 파일 경로에서 파일 이름만 추출하고 확장자를 제거한다
        List<string> prefabFileNames = prefabFiles
            .Select(filePath => Path.GetFileNameWithoutExtension(filePath))
            .ToList();

        return prefabFileNames;
    }

    private static void CreateDefaultScriptFile()
    {
        string defaultScript = @"
        using UnityEditor;
        
        public class CustomUIRegister
        {

        }";

        Directory.CreateDirectory(Path.GetDirectoryName(ScriptFilePath));
        File.WriteAllText(ScriptFilePath, defaultScript.Trim());
    }

    private static string GenerateScriptCode(List<string> prefabFiles)
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine("using UnityEditor;");
        sb.AppendLine();
        sb.AppendLine("public class CustomUIRegister");
        sb.AppendLine("{");

        foreach (var filename in prefabFiles)
        {
            sb.AppendLine($@"[MenuItem(""GameObject/Custom UI/{filename}"")]");
            sb.AppendLine($@"public static void Generate_{filename.Replace(" ", "_")}() => CustomUIPrefabSystem.CreateCustomUIPrefab(""{filename}"");");
        }

        sb.AppendLine("}");

        return sb.ToString().Trim();
    }

    private static void RemoveObsoleteCode(List<string> currentPrefabs, List<string> savedPrefabs)
    {
        if (!File.Exists(ScriptFilePath))
        {
            return;
        }

        string[] scriptLines = File.ReadAllLines(ScriptFilePath);
        StringBuilder sb = new StringBuilder();
        bool insideCodeBlock = false;

        foreach (var line in scriptLines)
        {
            if (line.Contains("[MenuItem(\"GameObject/Custom UI/") && !currentPrefabs.Any(p => line.Contains(p)))
            {
                insideCodeBlock = true;
            }

            if (!insideCodeBlock)
            {
                sb.AppendLine(line);
            } 

            if (insideCodeBlock && line.Trim().EndsWith(");"))
            {
                insideCodeBlock = false;
            }
        }

        File.WriteAllText(ScriptFilePath, sb.ToString());
    }
}