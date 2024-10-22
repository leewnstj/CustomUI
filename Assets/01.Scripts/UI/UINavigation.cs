using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

/// <summary>
/// UIView 관리
/// </summary>
public class UINavigation : MonoBehaviour
{
    private Stack<UIView> _showingUI = new();
    private Dictionary<string, UIView> _uiViews = new();

    private void Start()
    {
        UIView[] views = GetComponentsInChildren<UIView>();

        foreach(UIView view in views)
        {
            _uiViews.Add(view.name, view);
            view.HideUI();
        }
    }

    /// <summary>
    /// 해당 UIView 켜기
    /// </summary>
    /// <param name="viewName"></param>
    /// <returns></returns>
    public UIView Push(string viewName)
    {
        if(_showingUI.Count > 0)
        {
            _showingUI.Pop().HideUI();
        }

        if(_uiViews.TryGetValue(viewName, out UIView view))
        {
            _showingUI.Push(view);
            view.ShowUI();

            return view;
        }

        Debug.LogError($"{viewName} is NULL!");
        return null;
    }

    /// <summary>
    /// 현재 UIView 끄기
    /// </summary>
    /// <returns></returns>
    public UIView Pop()
    {
        _showingUI.Peek().HideUI();

        return _showingUI.Pop();
    }

    /// <summary>
    /// 해당 UIView까지 켜져있는 UIView끄기
    /// </summary>
    /// <param name="viewName"></param>
    /// <returns></returns>
    public UIView PopTo(string viewName)
    {
        _uiViews.TryGetValue(viewName, out UIView view);

        foreach(UIView v in _showingUI)
        {
            if(v == view)
            {
                break;
            }

            v.HideUI();
            _showingUI.Pop();
        }

        return _showingUI.Peek();
    }
}