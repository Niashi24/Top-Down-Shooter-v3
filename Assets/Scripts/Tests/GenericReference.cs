using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

[System.Serializable]
public struct GenericReference<T>
    where T : class
{
    [OnValueChanged(nameof(ValidateT))]
    [SerializeField]
    [HideLabel]
    [ValidateInput(
        nameof(IsValid),
        "Incorrect Type"
    )]
    [InlineButton(nameof(Reset), "X")]
    Object _value;

    public T Value {
        get => _value as T;
        set => _value = value as Object;
    }

    private bool IsValid => _value is T;
    private void ValidateT() {
        var gameobject = _value as GameObject;
        if (gameobject)
            _value = gameobject.GetComponent<T>() as MonoBehaviour;

        if (!IsValid) Reset();
    }

    void Reset() {
        _value = null;
    }
}
