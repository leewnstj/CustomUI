using UnityEngine;
using Util;

public class OpenUIViewButton : Button_Root
{
    [SerializeField] private string _uiViewName;

    private UINavigation _parentUI;

    protected override void Awake()
    {
        base.Awake();

        _parentUI = FindObjectUtil.FindParent<UINavigation>(this.gameObject);
    }

    public override void OnButtonClick()
    {
        _parentUI.Push(_uiViewName);
    }
}