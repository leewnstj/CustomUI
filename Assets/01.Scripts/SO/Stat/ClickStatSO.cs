using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SO/Stat")]
public class ClickStatSO : ScriptableObject
{
    public int TapDamage { get; set; }

    public void Clone(int tapDamage)
    {
        TapDamage = tapDamage;
    }
}