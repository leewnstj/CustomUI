using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    [SerializeField]
    private UIUpdateController _controller;

    private void Start()
    {
        _controller.OnUpdateText(UIType.Resource, "Coin", i.ToString());
        _controller.OnUpdateText(UIType.Resource, "Gem", j.ToString());
    }
    private int i = 0;
    private int j = 100;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            i++;
            _controller.OnUpdateText(UIType.Resource, "Coin", i.ToString());
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            i--;
            _controller.OnUpdateText(UIType.Resource, "Coin", i.ToString());
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            j++;
            _controller.OnUpdateText(UIType.Resource, "Gem", j.ToString());
        }
        if (Input.GetKeyDown(KeyCode.Z))
        {
            j--;
            _controller.OnUpdateText(UIType.Resource, "Gem", j.ToString());
        }
    }
}