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