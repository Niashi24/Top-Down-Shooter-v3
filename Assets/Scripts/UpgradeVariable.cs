using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

[CreateAssetMenu]
public class UpgradeVariable : ScriptableObject
{
    [SerializeField] List<IntTypePair<int>> valuesPerLevel;

    public int this[int level] {get {
        if (valuesPerLevel == null || valuesPerLevel.Count == 0)
        {
            Debug.LogWarning("No Upgrade Values", this);
            return 0;
        }

        var upgrade = valuesPerLevel.Find(x => x.I == level);
        if (upgrade == null) 
            upgrade = valuesPerLevel[valuesPerLevel.Count - 1];
        return upgrade.Value;
    }}
}
