using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HealthPickup : MonoBehaviour
{
    [SerializeField] int healthRestored = 1;
    [SerializeField] UnityEvent OnPickup;

    void OnTriggerEnter2D(Collider2D other) {
        var health = other.GetComponent<Health>();
        if (health) {
            health.Heal(healthRestored);
            OnPickup?.Invoke();
            Destroy(gameObject);
        }

    }
}
