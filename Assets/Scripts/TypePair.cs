using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

[System.Serializable]
public class TypePair<T1, T2>
{
    [HorizontalGroup(width: 10), HideLabel]
    public T1 Value1;

    [HorizontalGroup, HideLabel]
    public T2 Value2;
}
