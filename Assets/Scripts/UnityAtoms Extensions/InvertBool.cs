using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityAtoms.BaseAtoms;

public class InvertBool : MonoBehaviour
{
    [SerializeField] BoolReference _bool;
    public void Invert() {
        _bool.Value = !_bool.Value;
    }
}
