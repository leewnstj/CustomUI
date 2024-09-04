using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class CustomUIData
{
    private const string PrefabInfoFilePath = "Assets/Editor/PrefabInfo.json";

    public static List<string> LoadSavedPrefabInfo()
    {
        if (!File.Exists(PrefabInfoFilePath))
        {
            return new List<string>();
        }

        var json = File.ReadAllText(PrefabInfoFilePath);
        var prefabInfo = JsonUtility.FromJson<PrefabInfo>(json);
        return prefabInfo.Prefabs;
    }

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