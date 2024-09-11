using UnityEditor;

public class CustomUIRegister
{
[MenuItem("GameObject/Custom UI/Dim", false, 1)]
public static void Generate_Dim() => CustomUIPrefabSystem.CreateCustomUIPrefab("Dim");
[MenuItem("GameObject/Custom UI/EventButton", false, 1)]
public static void Generate_EventButton() => CustomUIPrefabSystem.CreateCustomUIPrefab("EventButton");
[MenuItem("GameObject/Custom UI/HorizontalGroup", false, 1)]
public static void Generate_HorizontalGroup() => CustomUIPrefabSystem.CreateCustomUIPrefab("HorizontalGroup");
[MenuItem("GameObject/Custom UI/Panel", false, 1)]
public static void Generate_Panel() => CustomUIPrefabSystem.CreateCustomUIPrefab("Panel");
[MenuItem("GameObject/Custom UI/ResourceUI", false, 1)]
public static void Generate_ResourceUI() => CustomUIPrefabSystem.CreateCustomUIPrefab("ResourceUI");
[MenuItem("GameObject/Custom UI/SlotPanel", false, 1)]
public static void Generate_SlotPanel() => CustomUIPrefabSystem.CreateCustomUIPrefab("SlotPanel");
[MenuItem("GameObject/Custom UI/UINavigation", false, 1)]
public static void Generate_UINavigation() => CustomUIPrefabSystem.CreateCustomUIPrefab("UINavigation");
[MenuItem("GameObject/Custom UI/UIView", false, 1)]
public static void Generate_UIView() => CustomUIPrefabSystem.CreateCustomUIPrefab("UIView");
[MenuItem("GameObject/Custom UI/VerticalGroup", false, 1)]
public static void Generate_VerticalGroup() => CustomUIPrefabSystem.CreateCustomUIPrefab("VerticalGroup");
}
