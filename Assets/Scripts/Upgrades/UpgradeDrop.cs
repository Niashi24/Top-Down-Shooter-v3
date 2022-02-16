using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityAtoms.BaseAtoms;
using UnityEngine.Events;
using Sirenix.OdinInspector;

public class UpgradeDrop : MonoBehaviour
{
    [SerializeField] IntReference _upgradeLevel;
    public const int MAX_UPGRADE_LEVEL = 3;

    [SerializeField] UnityEvent OnCollect;

    [ShowInInspector, ReadOnly]
    bool collected;
    
    void OnTriggerEnter2D(Collider2D other) {
        if (collected) return;

        if (other.CompareTag(Tags.Player)) {
            _upgradeLevel.Value = Mathf.Min(_upgradeLevel.Value + 1, MAX_UPGRADE_LEVEL);
            collected = true;
            OnCollect?.Invoke();
        }    
    }
}
