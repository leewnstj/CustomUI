using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// UI 객체 업데이트 관리
/// </summary>
public class UIUpdateController : MonoBehaviour
{
    /// <summary>
    /// Key를 2개를 가지는 Dictionary
    /// </summary>
    private MultiKeyDictionary<UIType, string, List<IUIUpdater>> _updateDatas = new();

    private void Awake()
    {
        Regist_UIUpdater();
    }

    /// <summary>
    /// UIView 등록하기
    /// </summary>
    private void Regist_UIUpdater()
    {
        IUIUpdater[] texts = GetComponentsInChildren<IUIUpdater>();

        foreach (IUIUpdater text in texts)
        {
            if (_updateDatas.TryGetValue(text.Type, text.Key, out List<IUIUpdater> list))
            {
                list.Add(text);
            }
            else
            {
                _updateDatas.Add(text.Type, text.Key, new List<IUIUpdater> { text });
            }
        }
    }

    /// <summary>
    /// Type과 Key로 저장된 UI를 업데이트해준다.
    /// </summary>
    /// <param name="type">UI의 Type</param>
    /// <param name="key">UI Key</param>
    /// <param name="content">업데이트 해줄 내용</param>
    public void OnUpdateUI(UIType type, string key, object content)
    {
        if(_updateDatas.TryGetValue(type, key, out List<IUIUpdater> list))
        {
            foreach(IUIUpdater text in list)
            {
                text.UpdateHandler(content);
            }
        }
        else
        {
            Debug.LogError("No equivalent UIView found");
        }
    }
}