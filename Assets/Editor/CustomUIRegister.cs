using UnityEditor;

public class CustomUIRegister
{
[MenuItem("GameObject/Custom UI/EventButton", false, 1)]
public static void Generate_EventButton() => CustomUIPrefabSystem.CreateCustomUIPrefab("EventButton");
[MenuItem("GameObject/Custom UI/HorizontalGroup", false, 1)]
public static void Generate_HorizontalGroup() => CustomUIPrefabSystem.CreateCustomUIPrefab("HorizontalGroup");
[MenuItem("GameObject/Custom UI/ResourceUI", false, 1)]
public static void Generate_ResourceUI() => CustomUIPrefabSystem.CreateCustomUIPrefab("ResourceUI");
}
