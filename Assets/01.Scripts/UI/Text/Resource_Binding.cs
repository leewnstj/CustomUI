using TMPro;
using UnityEngine;  

/// <summary>
/// 자원 텍스트 업데이트
/// </summary>
public class Resource_Binding : UIView, IUIUpdater
{
    [Header("Component")]
    [SerializeField] private TextMeshProUGUI _text;

    [Header("Binding_Data")]
    [SerializeField] private UIType _type;
    [SerializeField] private string _key;

    public UIType Type => _type;
    public string Key => _key;

    public void UpdateHandler(object content)
    {
        _text.ConvertNumber(content.ToString());
    }
}