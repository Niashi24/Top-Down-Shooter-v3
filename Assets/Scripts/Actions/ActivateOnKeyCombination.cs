using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ActivateOnKeyCombination : MonoBehaviour
{
    [SerializeField] KeyCode[] codes;
    [SerializeField] UnityEvent OnActivate;
    [SerializeField] float _coolDown = 1f;
    private float timer = 0;

    public bool AllPressed {get {
        foreach (var key in codes)
            if (!Input.GetKey(key)) return false;
        return true;
    }}

    void Update() {
        timer = Mathf.Max(0, timer - Time.deltaTime);
        if (timer != 0) return;

        if (AllPressed) {
            timer = _coolDown;
            OnActivate?.Invoke();
        }    
    }
}
