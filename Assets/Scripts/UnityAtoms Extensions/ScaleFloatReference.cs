using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityAtoms.BaseAtoms;

public class ScaleFloatReference : MonoBehaviour
{
    [SerializeField] FloatReference _floatReference;
    [SerializeField] AnimationCurve _curve;

    public void UpdateFloatReference(float t) {
        t = _curve.Evaluate(t);
        _floatReference.Value = t;
    }
}
