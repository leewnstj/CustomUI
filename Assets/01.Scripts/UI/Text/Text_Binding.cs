using TMPro;
using UnityEngine;  

public class Text_Binding : MonoBehaviour
{
    [Header("Component")]
    [SerializeField] private TextMeshProUGUI _text;

    [Header("Binding_Data")]
    [SerializeField] private UIType _type;
    [SerializeField] private string _key;

    public UIType Type => _type;
    public string Key => _key;

    public void Text_Update(string text)
    {
        _text.ConvertNumber(text);
    }
}