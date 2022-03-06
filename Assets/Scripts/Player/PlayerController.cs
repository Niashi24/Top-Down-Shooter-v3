using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;
using System;
using Sirenix.OdinInspector;

public class PlayerController : MonoBehaviour
{
    [SerializeField] PlayerInput _input;
    [SerializeField] Health _health;
    [SerializeField] PlayerStats _stats;
    [SerializeField] float _speed;

    [SerializeField] float _invincibilityTime = 1;
    [ReadOnly, ShowInInspector]
    private float invincibilityTimer = 0;
    [ReadOnly, ShowInInspector]
    public bool IsInvincible => invincibilityTimer > 0;

    public UnityEvent<PlayerController> OnGetHit;
    public UnityEvent<PlayerController> OnDeath;

    public const int ramDamage = 1;

    private Rigidbody2D rbdy2D;

    void Awake() {
        rbdy2D = GetComponent<Rigidbody2D>();
        ResetHealth();
    }

    void ResetHealth()
    {
        _health.SetMaxHealth(_stats.MaxHealth);
        _health.Heal(_health.MaxHealth);
    }

    void FixedUpdate() {
        if (!CanUpdate()) return;
        transform.Translate(
            _speed * Time.deltaTime * _input.Direction.normalized,
            Space.World
        );
         
        //rbdy2D.MovePosition(rbdy2D.position + _speed * Time.deltaTime * _input.Direction.normalized);

        invincibilityTimer = Mathf.Max(0, invincibilityTimer - Time.deltaTime);
    }

    bool CanUpdate() {
        if (GameManager.I == null) 
            return true;
        return GameManager.I.State == GameState.Game;
    }

    void OnCollisionEnter2D(Collision2D other) {
        if (this.IsEnemyTo(other.gameObject)) {
            TakeDamage(1);
        }
    }

    public void TakeDamage(int damage) {
        if (_health.CurrentHealth == 0) return;
        if (invincibilityTimer > 0) return;

        _health.TakeDamage(damage);
        OnGetHit?.Invoke(this);

        if (_health.CurrentHealth == 0) {
            OnDeath?.Invoke(this);
            Destroy(gameObject);
            return;
        }

        invincibilityTimer = _invincibilityTime;
    }
    
    //Methods todo:

    //OnCollisionEnter2D
        //Take damage from bullets
        //Take damage from ramming enemy ships
    //void Heal(int heal)
    //void TakeDamage(int damage)
        //Have Invincibility Frames
        //Flash (separate script)
}
