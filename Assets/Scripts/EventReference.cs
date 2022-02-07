using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;
using Sirenix.OdinInspector;

[System.Serializable]
public class EventReference<T>
{
    [SerializeField] UnityAction<T> unityAction;
    
    public event Action<T> OnTrigger {
        add => unityAction += (UnityAction<T>)value.Target;
        remove => unityAction -= (UnityAction<T>)value.Target;
    }

    public void Invoke(T value) {
        unityAction?.Invoke(value);
    }
}
