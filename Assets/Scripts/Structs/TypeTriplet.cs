using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

[System.Serializable]
public class TypeTriplet<T1, T2, T3>
{
    [HorizontalGroup, HideLabel]
    public T1 Value1;

    [HorizontalGroup, HideLabel]
    public T2 Value2;

    [HorizontalGroup, HideLabel]
    public T3 Value3;

    public override string ToString()
    {
        return $"T1: {Value1}, T2: {Value2}, T3: {Value3}";
    }
}
