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
        "@IsT || IsNull",
        "Incorrect Type"
    )]
    [InlineButton(nameof(Reset), "X")]
    Object _value;

    public T Value {
        get => _value as T;
        set => _value = value as Object;
    }

    private bool IsT => _value is T;
    private bool IsNull => _value == null;
    private void ValidateT() {
        var gameobject = _value as GameObject;
        if (gameobject && typeof(T) != typeof(GameObject))
            _value = gameobject.GetComponent<T>() as MonoBehaviour;

        if (!IsT) {
            Reset();
            Debug.Log($"Must be type {typeof(T)}");
        }
    }

    void Reset() {
        _value = null;
    }
}
