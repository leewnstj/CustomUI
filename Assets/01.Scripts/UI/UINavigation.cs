using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class UINavigation : MonoBehaviour
{
    private Stack<UIView> _showingUI = new();
    private Dictionary<string, UIView> _uiViews = new();

    private void Awake()
    {
        UIView[] views = GetComponentsInChildren<UIView>();

        foreach(UIView view in views)
        {
            _uiViews.Add(view.name, view);
            view.HideUI();
        }
    }

    public UIView Push(string viewName)
    {
        if(_showingUI.Count > 0)
        {
            _showingUI.Pop().HideUI();
        }

        _uiViews.TryGetValue(viewName, out UIView view);

        _showingUI.Push(view);
        view.ShowUI();

        return view;
    }

    public UIView Pop()
    {
        _showingUI.Pop();
        return _showingUI.Peek();
    }

    public UIView PopTo(string viewName)
    {
        _uiViews.TryGetValue(viewName, out UIView view);

        foreach(UIView v in _showingUI)
        {
            if(v == view)
            {
                break;
            }
            _showingUI.Pop();
        }

        return _showingUI.Peek();
    }

    public UIView PopToRoot()
    {
        foreach (UIView v in _showingUI)
        {
            if(_showingUI.Count == 1)
            {
                break;
            }

            _showingUI.Pop();
        }

        return _showingUI.Peek();
    }
}