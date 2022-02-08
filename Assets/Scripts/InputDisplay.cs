using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public partial class InputDisplay : MonoBehaviour
{
    [SerializeField] InputSettings _input;

    [Header("Input Displays")]
    [SerializeField] KeyDisplay _up;
    [SerializeField] KeyDisplay _down;
    [SerializeField] KeyDisplay _left;
    [SerializeField] KeyDisplay _right;
    [SerializeField] KeyDisplay _shoot;

    [SerializeField] UnityEvent OnAllActive;
    bool triggeredEvent;

    void Update() {
        SetActiveIfPressedAll();

        if (!triggeredEvent && AllAreActive) {
            OnAllActive?.Invoke();
            triggeredEvent = true;
        }
    }

    void SetActiveIfPressedAll() {
        //Probably a better way to do this but whatever
        SetActiveIfPressed(_up, _input.Up);
        SetActiveIfPressed(_right, _input.Right);
        SetActiveIfPressed(_down, _input.Down);
        SetActiveIfPressed(_left, _input.Left);
        SetActiveIfPressed(_shoot, _input.Confirm);
    }

    void SetActiveIfPressed(KeyDisplay image, KeyCode key) {
        if (image.active) return;
        
        image.SetActive(Input.GetKeyDown(key));
    }

    public bool AllAreActive {get =>
        _up.active && _right.active && _left.active && _down.active && _shoot.active;
    }
}
