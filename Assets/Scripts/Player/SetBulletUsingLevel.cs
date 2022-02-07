using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityAtoms.BaseAtoms;

public class SetBulletUsingLevel : MonoBehaviour
{
    [SerializeField]
    SkillTreeReference _skillTreeReference;

    [SerializeField]
    IntReference _level;

    [SerializeField]
    BulletPrefabReference _prefabReference;

    void OnEnable() {
        _skillTreeReference.OnChange += (x) => UpdateReference();
    }

    void Start() => UpdateReference();

    public void UpdateReference() {
        _prefabReference.Value = _skillTreeReference.Value[_level.Value].BulletPrefab;
    }
}
