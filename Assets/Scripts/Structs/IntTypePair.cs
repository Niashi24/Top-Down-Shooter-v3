using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

[System.Serializable]
public class IntTypePair<T>
{
    [HorizontalGroup(width: 20), HideLabel]
    public int I;
    [HorizontalGroup, HideLabel]
    public T Value;
}
