using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResourceButton : MonoBehaviour
{
    [SerializeField] private ButtonEventType _buttonType;
    private Button _button;

    private void Awake()
    {
        _button = GetComponent<Button>();
        _button.onClick.AddListener(ButtonEvent);
    }

    public void ButtonEvent()
    {
        
    }
}