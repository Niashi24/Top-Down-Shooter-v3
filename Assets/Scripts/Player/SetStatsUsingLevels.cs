using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityAtoms.BaseAtoms;

public class SetStatsUsingLevels : MonoBehaviour
{
    [SerializeField]
    PlayerStats stats;
    [Header("Stat Levels")]
    [SerializeField] IntReference _fireRateLevel;
    [SerializeField] IntReference _pierceLevel;
    [SerializeField] IntReference _damageLevel;
    [SerializeField] IntReference _healthLevel;
    [Header("Stat Upgrades")]
    [SerializeField] UpgradeVariable _fireRateUpgrade;
    [SerializeField] UpgradeVariable _pierceUpgrade;
    [SerializeField] UpgradeVariable _damageUpgrade;
    [SerializeField] UpgradeVariable _healthUpgrade;

    void Start() {
        UpdateAllStats();
    }

    public void UpdateAllStats() {
        UpdateDamage();
        UpdateFireRate();
        UpdateHealth();
        UpdatePierce();
    }

    // [SerializeField] 
    // List<TypePair<TypePair<IntReference, IntReference>, UpgradeVariable>> ValueLevelUpgrade;

    public void UpdateStat(Stats stat) {
        switch (stat) {
            case Stats.Damage:
                stats.SetDamage(_damageUpgrade[_damageLevel.Value]);
                break;
            case Stats.FireRate:
                stats.SetSPS(_fireRateUpgrade[_fireRateLevel.Value]);
                break;
            case Stats.Health:
                stats.SetHealth(_healthUpgrade[_healthLevel.Value]);
                break;
            case Stats.Pierce:
                stats.SetPierce(_pierceUpgrade[_pierceLevel.Value]);
                break;
        }
    }

    public void UpdateDamage() {
        stats.SetDamage(_damageUpgrade[_damageLevel.Value]);
    }

    public void UpdateFireRate() {
        stats.SetSPS(_fireRateUpgrade[_fireRateLevel.Value]);
    }

    public void UpdateHealth() {
        stats.SetHealth(_healthUpgrade[_healthLevel.Value]);
    }

    public void UpdatePierce() {
        stats.SetPierce(_pierceUpgrade[_pierceLevel.Value]);
    }
}
