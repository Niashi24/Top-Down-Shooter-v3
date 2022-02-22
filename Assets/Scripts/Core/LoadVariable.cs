using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityAtoms.BaseAtoms;

public class LoadVariable : MonoBehaviour
{
    [SerializeField] IntReference _toLoad;
    [SerializeField] string key;
    [SerializeField] bool onAwake;

    void Awake() {
        if (onAwake) Load();    
    }

    public void Load() {
        if (PlayerPrefs.HasKey(key))
            _toLoad.Value = PlayerPrefs.GetInt(key);
    }
}
