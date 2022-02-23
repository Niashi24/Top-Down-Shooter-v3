using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using System.Linq;

[CreateAssetMenu(menuName = "Skill Tree/Value")]
public class SkillTree : ScriptableObject
{
    [SerializeField, TextArea(1, 10)] string description;
    public string Description => description;

    [SerializeField] Upgrade _defaultLevel;

    [SerializeField] 
    [OnValueChanged(nameof(SortLevels), true)]
    List<IntTypePair<Upgrade>> Levels;

    public Upgrade this[int exp] {get {
        foreach (var prefab in Levels) {
            if (prefab.I == exp)
                return prefab.Value;
        }
        return _defaultLevel;
    }}

    private void SortLevels() => Levels = Levels.OrderBy(x => x.I).ToList();
}
