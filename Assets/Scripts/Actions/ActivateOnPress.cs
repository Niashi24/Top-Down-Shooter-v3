using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ActivateOnPress : MonoBehaviour
{
    [SerializeField] KeyCode _keyCode;

    [SerializeField] UnityEvent OnPress;

    void Update() {
        if (Input.GetKeyDown(_keyCode)) OnPress?.Invoke();
    }
}
