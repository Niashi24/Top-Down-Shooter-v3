using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityAtoms.BaseAtoms;

[CreateAssetMenu]
public class PlayerStats : ScriptableObject
{
    public event System.Action<PlayerStats> OnStatChange;

    [SerializeField] IntReference shotsPerSecond;
    public int ShotsPerSecond => shotsPerSecond.Value;
    [SerializeField] IntReference pierce;
    public int Pierce => pierce.Value;
    [SerializeField] IntReference damage;
    public int Damage => damage.Value;
    [SerializeField] IntReference health;
    public int Health => health.Value;

    public void SetSPS(int newSPS) {
        shotsPerSecond.Value = newSPS;
        OnStatChange?.Invoke(this);
    }

    public void SetPierce(int newPierce) {
        pierce.Value = newPierce;
        OnStatChange?.Invoke(this);
    }

    public void SetDamage(int newDamage) {
        damage.Value = newDamage;
        OnStatChange?.Invoke(this);
    }

    public void SetHealth(int newPierce) {
        pierce.Value = newPierce;
        OnStatChange?.Invoke(this);
    }
}
