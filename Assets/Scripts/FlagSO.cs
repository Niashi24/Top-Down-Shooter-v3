using UnityEngine;

public abstract class FlagSO<T> : ScriptableObject
{
    [SerializeField]
    private T initialValue;

    public T Value;

    void OnEnable() {
        Value = initialValue;    
    }
}