using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceManager : MonoSingleton<ResourceManager>
{
    private void Awake()
    {
        DontDestroyOnLoad(this);
    }
}