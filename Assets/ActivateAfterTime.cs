using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ActivateAfterTime : MonoBehaviour
{
    [SerializeField] float _time;
    [SerializeField] UnityEvent OnTrigger;
    [SerializeField] bool onStart;
    float timer = 0;
    bool started;
    bool triggered;

    void Start() {
        timer = _time;
        if (onStart) StartTimer();    
    }

    public void StartTimer() {
        timer = _time;
        started = true;
        triggered = false;
    }

    void Update() {
        if (started)
            timer -= Time.deltaTime;
        if (timer <= 0 && !triggered) {
            triggered = true;
            OnTrigger?.Invoke();
        }
    }
}
