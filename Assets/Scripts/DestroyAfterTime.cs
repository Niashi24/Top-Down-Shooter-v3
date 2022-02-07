using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterTime : MonoBehaviour
{
    [SerializeField] float _time;

    void Start()
    {
        Destroy(gameObject, _time);
    }
}
