using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class UIUpdateController : MonoBehaviour
{
    private MultiKeyDictionary<UIType, string, List<Text_Binding>> _textDatas = new();

    private void Awake()
    {
        Regist_Text();
    }

    private void Regist_Text()
    {
        Text_Binding[] texts = GetComponentsInChildren<Text_Binding>();

        foreach (Text_Binding text in texts)
        {
            if (_textDatas.TryGetValue(text.Type, text.Key, out List<Text_Binding> list))
            {
                list.Add(text);
            }
            else
            {
                _textDatas.Add(text.Type, text.Key, new List<Text_Binding> { text });
            }
        }
    }

    /// <summary>
    /// Type과 Key로 저장된 UI를 업데이트해준다.
    /// </summary>
    /// <param name="type">UI의 Type</param>
    /// <param name="key">UI Key</param>
    /// <param name="value">업데이트 해줄 내용</param>
    public void OnUpdateText(UIType type, string key, string value)
    {
        if(_textDatas.TryGetValue(type, key, out List<Text_Binding> list))
        {
            foreach(Text_Binding text in list)
            {
                text.Text_Update(value);
            }
        }
        else
        {
            Debug.LogError("No equivalent Text_Binding found");
        }
    }
}