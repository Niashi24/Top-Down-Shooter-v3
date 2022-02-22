using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityAtoms.BaseAtoms;

public class SaveVariable : MonoBehaviour
{
    [SerializeField] IntReference _toSave;
    [SerializeField] string key;

    public void Save() {
        PlayerPrefs.SetInt(key, _toSave.Value);
        PlayerPrefs.Save();
    }
}
