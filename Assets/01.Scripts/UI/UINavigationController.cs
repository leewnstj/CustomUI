using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// UINavigation을 관리
/// </summary>
public class UINavigationController : MonoBehaviour
{
    private Stack<UINavigation> _showingUI = new();
    private Dictionary<string, UINavigation> _uiNavigations = new();

    private void Awake()
    {
        UINavigation[] uiNavigations = GetComponentsInChildren<UINavigation>();

        foreach (UINavigation view in uiNavigations)
        {
            _uiNavigations.Add(view.name, view);
            view.gameObject.SetActive(false);
        }
    }

    /// <summary>
    /// 해당 네비게이션을 킨다
    /// </summary>
    /// <param name="navigationName">해당 네비게이션의 이름</param>
    /// <returns></returns>
    public UINavigation Navigation_Push(string navigationName)
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

    /// <summary>
    /// 켜져있는 네비게이션을 끈다
    /// </summary>
    /// <returns></returns>
    public UINavigation Navigation_Pop()
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

    /// <summary>
    /// 해당 네비게이션까지 켜져있는 네비게이션들을 끈다
    /// </summary>
    /// <param name="navigationName">해당 네비게이션의 이름</param>
    /// <returns></returns>
    public UINavigation Navigation_PopTo(string navigationName)
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

    /// <summary>
    /// 가장 처음 켜졌었던 네비게이션까지 네비게이션들을 끈다
    /// </summary>
    /// <returns></returns>
    public UINavigation Navigation_PopToRoot()
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
