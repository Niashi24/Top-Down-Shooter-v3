using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;

public class ScorePanel : MonoBehaviour
{
    [SerializeField] ScoreTracker _tracker;
    [SerializeField] ScoreDisplayUnit[] _units;
    [SerializeField] Text _total;

    [SerializeField] float _timeBetweenFlips;
    
    void OnEnable() {
        StartCoroutine(ScoreDisplayCoroutine());
    }

    private IEnumerator ScoreDisplayCoroutine()
    {
        foreach (var unit in _units) unit.SetActive(false);
        _total.gameObject.SetActive(false);

        var WaitBetweenFlips = new WaitForSeconds(_timeBetweenFlips);
        //give time for score display to move in
        yield return WaitBetweenFlips;

        var score = _tracker.Values;
        if (score.Length > _units.Length) Debug.LogWarning("Not enough units for score panel", this);
        for (int i = 0; i < _units.Length; i++) {
            if (i >= score.Length) {
                _units[i].SetActive(false);
                continue;
            }
            var unit = _units[i];
            var (identifier, kills) = score[i];
            unit.SetValues(identifier, kills);
            unit.SetActive(true);
            yield return WaitBetweenFlips;
        }
        
        _total.text = _tracker.Total.ToString();
        _total.gameObject.SetActive(true);
    }
}
