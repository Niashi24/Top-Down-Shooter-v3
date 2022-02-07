using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class SetFlag<T> : MonoBehaviour
{
    [SerializeField, HorizontalGroup]
    FlagSO<T> flag;

    [ShowInInspector, ReadOnly, HorizontalGroup, HideLabel]
    private T value => flag.Value;

    [Button]
    public void SetValue(T newValue) {
        flag.Value = newValue;
    }
}
