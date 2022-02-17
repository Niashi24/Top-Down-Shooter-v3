using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using Sirenix.OdinInspector;

[CreateAssetMenu]
public class ScoreTracker : ScriptableObject, IResettable
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
    
    [ShowInInspector, ReadOnly]
    public (ScoreIdentifier, int)[] Values =>
        killsPerType.Map(x => (x.Key, x.Value)).ToArray();

    [ShowInInspector, ReadOnly]
    public int Total => killsPerType.Sum(x => x.Key.ScorePerKill * x.Value);
}