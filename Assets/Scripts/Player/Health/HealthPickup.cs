using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    [SerializeField] int healthRestored = 1;

    void OnTriggerEnter2D(Collider2D other) {
        var health = other.GetComponent<Health>();
        if (health) {
            health.Heal(healthRestored);
            Destroy(gameObject);
        }   
    }
}
