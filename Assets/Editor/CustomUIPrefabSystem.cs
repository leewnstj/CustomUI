using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

// 새로 알게된 기능
// AssetDatabase.LoadAssetAtPath<불러올 오브젝트>(경로) 
// PrefabUtility.InstantiatePrefab(객체) 에디터에서 해당 객체를 생성한다 
// Undo.RegisterCreatedObjectUndo(,) 에디터에서 오브젝트를 생성하고, 해당 생성 작업을 Undo(되돌리기) 시스템에 등록하는 역할

public class CustomUIPrefabSystem
{
    /// <summary>
    /// 커스텀UI 프리펩 생성
    /// </summary>
    /// <param name="fileName">생성할 프리펩 이름</param>
    public static void CreateCustomUIPrefab(string fileName)
    {
        //프리펩 경로 찾기
        string prefabPath = $"Assets/Prefabs/CustomUI/{fileName}.prefab";

        GameObject prefab = AssetDatabase.LoadAssetAtPath<GameObject>(prefabPath);

        if(prefab == null)
        {
            Debug.LogError("UIPrefab not found at " + prefabPath);
            return;
        }

        GameObject instance = PrefabUtility.InstantiatePrefab(prefab) as GameObject;

        // 선택된 오브젝트가 있을 경우 해당 오브젝트의 자식으로 설정
        if (Selection.activeTransform != null)
        {
            instance.transform.SetParent(Selection.activeTransform, false);
        }

        Undo.RegisterCreatedObjectUndo(instance, "Create " + instance.name);
    }
}