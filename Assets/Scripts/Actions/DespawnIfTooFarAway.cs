using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DespawnIfTooFarAway : MonoBehaviour
{
    [SerializeField] Transform _point;
    [SerializeField] float _maxDistance = 30;

    void Update() {
        if (Vector2.Distance(_point.position, transform.position) > _maxDistance)
            Destroy(gameObject);    
    }

    void OnDrawGizmosSelected() {
        Gizmos.DrawWireSphere(transform.position, _maxDistance);    
    }
}
