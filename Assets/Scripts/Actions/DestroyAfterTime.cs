using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterTime : MonoBehaviour
{
    [SerializeField] float _time;
    [SerializeField] bool _activateOnStart = true;

    void Start()
    {
        if (_activateOnStart)
            StartDestroy();
    }

    public void StartDestroy() {
        Destroy(gameObject, _time);
    }
}
