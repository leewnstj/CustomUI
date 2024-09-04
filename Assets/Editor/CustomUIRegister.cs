using UnityEditor;

public class CustomUIRegister
{
[MenuItem("GameObject/Custom UI/ASD")]
public static void Generate_ASD() => CustomUIPrefabSystem.CreateCustomUIPrefab("ASD");
[MenuItem("GameObject/Custom UI/GameObject")]
public static void Generate_GameObject() => CustomUIPrefabSystem.CreateCustomUIPrefab("GameObject");
}
