using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ScoreObject : ScriptableObject, IResettable
{
    Dictionary<ScoreIdentifier, int> killsPerType;

    public int this[ScoreIdentifier scoreIdentifier] => killsPerType[scoreIdentifier];

    private void OnEnable() {
        Reset();
    }

    public void Reset() {
        killsPerType = new Dictionary<ScoreIdentifier, int>();
    }

    public void AddKill(ScoreIdentifier score) {
        if (!killsPerType.ContainsKey(score)) {
            killsPerType[score] = 1;
        } else {
            killsPerType[score]++;
        }
    }

    public (ScoreIdentifier, int)[] GetValues() {
        var keys = killsPerType.Keys.ToArray();
        (ScoreIdentifier, int)[] pairs = new (ScoreIdentifier, int)[keys.Length];
        for (int i = 0; i < keys.Length; i++)
            pairs[i] = (keys[i], killsPerType[keys[i]]);
        
        return pairs;
    } 
}