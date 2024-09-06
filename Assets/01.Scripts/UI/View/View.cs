using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class View : MonoBehaviour
{
    [SerializeField] private ViewEnum _viewType;
    public ViewEnum ViewType => _viewType;

    public abstract void OnViewUpdate();
}