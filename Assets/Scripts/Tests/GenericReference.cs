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
    [HideIf(nameof(IsValid))]
    Object _value;

    [InlineButton(nameof(Reset), "X")]
    [SerializeField, ShowIf(nameof(IsValid))] MonoBehaviour script;

    public T Value {
        get => script as T;
        set => script = value as MonoBehaviour;
    }

    private bool IsValid => script != null && script is T;
    private void ValidateT() {
        var gameobject = _value as GameObject;
        if (gameobject) {
            script = gameobject.GetComponent<T>() as MonoBehaviour;
        }

        if (!IsValid) _value = null;
    }

    void Reset() {
        _value = null;
        script = null;
    }
}
