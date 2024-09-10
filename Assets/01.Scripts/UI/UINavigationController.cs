using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UINavigationController : MonoBehaviour
{
    private static UINavigationController _instance { get; set; }

    private Stack<UINavigation> _showingUI = new();
    private Dictionary<string, UINavigation> _uiNavigations = new();

    private void Awake()
    {
        _instance = this;

        UINavigation[] uiNavigations = GetComponentsInChildren<UINavigation>();

        foreach (UINavigation view in uiNavigations)
        {
            _uiNavigations.Add(view.name, view);
            view.gameObject.SetActive(false);
        }
    }

    public static UINavigation Navigation_Push(string navigationName)
    {
        return _instance.Push(navigationName);
    }

    public static void Navigation_Pop()
    {
        _instance.Pop();
    }

    public static UINavigation Navigation_PopTo(string navigationName)
    {
        return _instance.PopTo(navigationName);
    }

    public static UINavigation Navigation_PopToRoot()
    {
        return _instance.PopToRoot();
    }

    private UINavigation Push(string navigationName)
    {
        if (_showingUI.Count > 0)
        {
            _showingUI.Peek().gameObject.SetActive(false);
        }

        if (_uiNavigations.TryGetValue(navigationName, out UINavigation uiNavigation) && uiNavigation != null)
        {
            _showingUI.Push(uiNavigation);
            uiNavigation.gameObject.SetActive(true);
            return uiNavigation;
        }

        Debug.LogWarning($"Navigation '{navigationName}' not found.");
        return null;
    }

    private UINavigation Pop()
    {
        if (_showingUI.Count > 0)
        {
            _showingUI.Pop().gameObject.SetActive(false);
        }

        if (_showingUI.Count > 0)
        {
            _showingUI.Peek().gameObject.SetActive(true);
            return _showingUI.Peek();
        }

        Debug.LogWarning("No more UI to pop.");
        return null;
    }

    private UINavigation PopTo(string navigationName)
    {
        if (_uiNavigations.TryGetValue(navigationName, out UINavigation targetUI) && targetUI != null)
        {
            while (_showingUI.Count > 0 && _showingUI.Peek() != targetUI)
            {
                _showingUI.Pop().gameObject.SetActive(false);
            }

            if (_showingUI.Count > 0)
            {
                _showingUI.Peek().gameObject.SetActive(true);
                return _showingUI.Peek();
            }
        }

        Debug.LogWarning($"Navigation '{navigationName}' not found.");
        return null;
    }

    private UINavigation PopToRoot()
    {
        while (_showingUI.Count > 1)
        {
            _showingUI.Pop().gameObject.SetActive(false);
        }

        if (_showingUI.Count > 0)
        {
            _showingUI.Peek().gameObject.SetActive(true);
            return _showingUI.Peek();
        }

        Debug.LogWarning("No UI found.");
        return null;
    }
}
