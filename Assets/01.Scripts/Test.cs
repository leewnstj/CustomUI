using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    private UINavigation _uiNavigation;

    public void Show_1()
    {
        _uiNavigation.Push("UIView_1");
    }
    public void Show_2()
    {
        _uiNavigation.Push("UIView_2");
    }
    public void Show_3()
    {
        _uiNavigation.Push("UIView_3");
    }
    public void Show_4()
    {
        _uiNavigation.Push("UIView_4");
    }

    public void Show_NV_1()
    {
        UINavigationController.Navigation_Push("Panel_1");
    }

    public void Show_NV_2()
    {
        UINavigationController.Navigation_Push("Panel_2");
    }
}
