using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
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
        if (Input.GetKey(KeyCode.D))
        {
            i += 500;
            _controller.OnUpdateText(UIType.Resource, "Coin", i.ToString());
        }
        if (Input.GetKey(KeyCode.A))
        {
            i -= 500;
            _controller.OnUpdateText(UIType.Resource, "Coin", i.ToString());
        }

        if (Input.GetKey(KeyCode.C))
        {
            j += 500;
            _controller.OnUpdateText(UIType.Resource, "Gem", j.ToString());
        }
        if (Input.GetKey(KeyCode.Z))
        {
            j -= 500;
            _controller.OnUpdateText(UIType.Resource, "Gem", j.ToString());
        }
    }
}