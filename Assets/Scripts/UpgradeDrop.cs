using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityAtoms.BaseAtoms;

public class UpgradeDrop : MonoBehaviour
{
    [SerializeField] IntReference _upgradeLevel;
    public const int MAX_UPGRADE_LEVEL = 3;
    
    void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag(Tags.Player)) {
            _upgradeLevel.Value = Mathf.Min(_upgradeLevel.Value + 1, MAX_UPGRADE_LEVEL);
            Destroy(gameObject);
        }    
    }
}
