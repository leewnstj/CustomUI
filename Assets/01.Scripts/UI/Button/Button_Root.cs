using UnityEngine;
using UnityEngine.UI;

public abstract class Button_Root : MonoBehaviour, IButtonEvent
{
    private Button _button;

    protected virtual void Awake()
    {
        _button = GetComponent<Button>();

        ButtonEventRegister();
    }

    protected virtual void ButtonEventRegister()
    {
        _button.onClick.AddListener(OnButtonClick);
    }

    public abstract void OnButtonClick();
}
