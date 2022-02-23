using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityAtoms.BaseAtoms;

public class DisableIf : MonoBehaviour
{
    [SerializeField] BoolReference _disable;
    [SerializeField] bool invert;
    [SerializeField] List<Behaviour> _toDisable;
    [SerializeField] bool onStart;

    void Start() {
        if (onStart) Activate();
    }

    public void Activate() {
        bool disabled = invert ? !_disable.Value : _disable.Value;
        _toDisable.ForEach(x => x.enabled = !disabled);
    }
}
