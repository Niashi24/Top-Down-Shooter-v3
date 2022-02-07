using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu(menuName = "Skill Tree/Reference")]
public class SkillTreeReference : ScriptableObject
{
    [SerializeField]
    SkillTree _value;
    
    public SkillTree Value {
        get {
            return _value;
        } set {
            _value = value;
            OnChange?.Invoke(value);
        }
    }

    public event Action<SkillTree> OnChange;
}
