using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton<T> : MonoBehaviour
    where T : Component
{
    public static T I {get; private set;}

    [SerializeField] T _instance;

    void Awake() {
        if (I == null) {
            I = _instance;
            DontDestroyOnLoad(I.gameObject);
        } else {
            Destroy(_instance);
        }
    }
}
