using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityAtoms.BaseAtoms;

public class ScalePlayerStats : MonoBehaviour
{
    [SerializeField] PlayerStats _initialStats;
    [SerializeField] PlayerStats _finalStats;
    [SerializeField] PlayerStats _statReference;
    [SerializeField] AnimationCurve _curve;

    public void UpdateStats(float t) {
        t = _curve.Evaluate(t);
        var damage = (int)Mathf.Round(Mathf.Lerp(_initialStats.Damage, _finalStats.Damage, t));
        var health = (int)Mathf.Round(Mathf.Lerp(_initialStats.MaxHealth, _finalStats.MaxHealth, t));
        var SPS = (int)Mathf.Round(Mathf.Lerp(_initialStats.ShotsPerSecond, _finalStats.ShotsPerSecond, t));
        var pierce = (int)Mathf.Round(Mathf.Lerp(_initialStats.Pierce, _finalStats.Pierce, t));

        _statReference.SetAll(
            damage,
            health,
            SPS,
            pierce
        );
    }
}
