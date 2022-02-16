using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Sirenix.OdinInspector;

[RequireComponent(typeof(Rigidbody2D))]
public class BulletScript : MonoBehaviour
{
    [SerializeField] float _speed;
    [SerializeField, Tooltip("Damage done when hitting an enemy")] 
    int damage;
    public int Damage => damage;

    [SerializeField, Tooltip("Ability to pierce through enemy bullets")] 
    int pierce;
    public int Pierce => pierce;

    public int currentHealth {get; private set;}

    [ShowInInspector, ReadOnly]
    protected Vector2 velocity;
    private Rigidbody2D rbdy2D;

    public event Action<BulletScript> OnBulletStart;
    public event Action<BulletScript> OnBulletDestroyed;

    public void SetStats(PlayerStats stats) {
        damage = stats.Damage;
        pierce = stats.Pierce;

        currentHealth = pierce;
        CalculateVelocity();
    }

    void CalculateVelocity() {
        float angle = Mathf.Deg2Rad * (transform.eulerAngles.z + 90);
        Vector2 direction = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));
        velocity = direction * _speed;
    }

    void Start() {
        currentHealth = pierce;
        CalculateVelocity();
        rbdy2D = GetComponent<Rigidbody2D>();

        OnBulletStart?.Invoke(this);
    }

    protected virtual void ChangeDirection() {}

    void FixedUpdate() {
        ChangeDirection();
        transform.position += (Vector3)velocity * Time.deltaTime;
        TurnTowardsVelocity();
        //rbdy2D.MovePosition((Vector2)transform.position + velocity * Time.deltaTime);
    }

    void TurnTowardsVelocity() {
        transform.eulerAngles = new Vector3(
            transform.eulerAngles.x,
            transform.eulerAngles.y,
            Mathf.Atan2(velocity.y, velocity.x) * Mathf.Rad2Deg - 90f
        );
    }

    void OnCollisionEnter2D(Collision2D collision) {
        switch (collision.gameObject.tag) {
            case Tags.Bullet:
                var bullet = collision.gameObject.GetComponent<BulletScript>();
                if (bullet == null) break;
                
                var theirHealth = bullet.currentHealth;
                currentHealth -= theirHealth;
                if (currentHealth <= 0) {
                    OnBulletDestroyed?.Invoke(this);
                    Destroy(gameObject);
                }
                break;
            
            default:
                var playerController = collision.gameObject.GetComponent<PlayerController>();
                if (playerController == null) break;
                playerController.TakeDamage(Damage);
                OnBulletDestroyed?.Invoke(this);
                Destroy(gameObject);
                break;

            // case Tags.Enemy:

            //     break;
        }
    }
}
