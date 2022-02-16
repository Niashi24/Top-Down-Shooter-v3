using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DestroyIfTooFarAwayFrom : MonoBehaviour
{
    [SerializeField] Transform _transform;
    [SerializeField] float _maxDistance;
    [SerializeField] UnityEvent OnDestroyed;

    void LateUpdate() {
        if (_transform == null) return;
        if (Vector2.Distance(transform.position, _transform.position) > _maxDistance)
        {
            OnDestroyed?.Invoke();
            Destroy(gameObject);
        }    
    }

    public void SetTransform(Transform newTransform) {
        _transform = newTransform;
    }
}
