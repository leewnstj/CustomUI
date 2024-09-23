using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Util;

public class CloseUIViewButton : Button_Root
{
    private UINavigation _parentUI;

    protected override void Awake()
    {
        base.Awake();

        _parentUI = FindObjectUtil.FindParent<UINavigation>(this.gameObject);
    }

    public override void OnButtonClick()
    {
        _parentUI.Pop();
    }
}
