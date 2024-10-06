using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

public class CustomUIData
{
    private const string PrefabInfoFilePath = "Assets/Editor/PrefabInfo.json";

    /// <summary>
    /// 현재 프리팹 목록을 Json으로 저장하여 다음 실행 시 이전 상태와 비교할 수 있도록 합니다.
    /// </summary>
    public static void SavePrefabInfo(List<string> prefabFiles)
    {
        File.WriteAllText(PrefabInfoFilePath, JsonUtility.ToJson(new PrefabInfo { Prefabs = prefabFiles }));
    }

    [System.Serializable]
    private class PrefabInfo
    {
        public List<string> Prefabs;
    }
}