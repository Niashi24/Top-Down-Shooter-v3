using System.Collections;
using System.Collections.Generic;
using UnityAtoms.BaseAtoms;
using UnityEngine;
using System;

public class Health : MonoBehaviour
{
    [SerializeField] IntReference _currentHealth;
    public int CurrentHealth => _currentHealth.Value;
    [SerializeField] IntReference _maxHealth;
    public int MaxHealth => _maxHealth.Value;

    public event Action OnDamage;
    public event Action OnHeal;
    public event Action OnDeath;

    void Start() {
        _currentHealth.Value = MaxHealth;    
    }

    public void SetMaxHealth(int maxHealth) {
        _maxHealth.Value = maxHealth;
    }

    public void TakeDamage(int damage) {
        //Debug.Log(damage);
        var newHealth = Mathf.Max(0, _currentHealth.Value - damage);
        var damageTaken = _currentHealth.Value - newHealth;
        if (damageTaken != 0) OnDamage?.Invoke();

        _currentHealth.Value = newHealth;
        

        if (_currentHealth.Value == 0) {
            if (OnDeath != null)
                OnDeath();
            else
                Destroy(gameObject);
        }
    }

    public void Heal(int heal) {
        _currentHealth.Value = Mathf.Min(_maxHealth.Value, _currentHealth.Value + heal);

        OnHeal?.Invoke();
    }
}
