using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityAtoms.BaseAtoms;
using UnityEngine.UI;

public class SetFormLabel : MonoBehaviour
{
    [SerializeField] BoolReference _variable;
    [SerializeField] Text _text;

    void OnEnable() {
        UpdateUI();
    }

    public void UpdateUI() {
        _text.text = _variable.Value ? "B" : "A";
    }
}
