using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ScorePanel : MonoBehaviour
{
    [SerializeField] ScoreTracker _tracker;
    [SerializeField] ScoreDisplayUnit[] _units;

    [SerializeField] float _timeBetweenFlips;
    
    void OnEnable() {
        StartCoroutine(ScoreDisplayCoroutine());
    }

    private IEnumerator ScoreDisplayCoroutine()
    {
        foreach (var unit in _units) unit.SetActive(false);
        var WaitBetweenFlips = new WaitForSeconds(_timeBetweenFlips);
        //give time for score display to move in
        yield return WaitBetweenFlips;

        var score = _tracker.Values;
        if (score.Length > _units.Length) Debug.LogWarning("Not enough units for score panel", this);
        for (int i = 0; i < _units.Length; i++) {
            var unit = _units[i];
            var (identifier, kills) = score[i];
            unit.SetValues(identifier, kills);
            unit.SetActive(true);
            yield return WaitBetweenFlips;
        }

        throw new NotImplementedException();
    }
}
