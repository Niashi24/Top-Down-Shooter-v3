using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

public class RadialBulletEditor : MonoBehaviour
{
    [SerializeField] GameObject _bulletPrefab;

    [SerializeField] List<GameObject> _bullets;
    [SerializeField, Min(1)] int _number = 4;
    [SerializeField, Range(0, 360)] float _angelOffset = 0f;
    const float distanceFromCenter = 0;

    [Button]
    public void Generate()
    {
        if (_bulletPrefab == null) return;
        if (_number < 1) return;

        ClearList();

        float rot = 360f / _number;

        float angle = _angelOffset + 90;
        for (int i = 0; i < _number; i++)
        {
            _bullets.Add(
                Instantiate(
                    _bulletPrefab,
                    GetPosition(transform.position, distanceFromCenter, angle),
                    Quaternion.Euler(0,0,angle - 90),
                    transform
                )
            );

            angle += rot;
        }

        if (TryGetComponent<BulletManager>(out var manager))
            manager.GetBullets();
    }

    void ClearList()
    {
        _bullets.ForEach(x => DestroyImmediate(x));
        _bullets.Clear();
    }

    public Vector3 GetPosition(Vector3 center, float radius, float angle) {
        angle *= Mathf.Deg2Rad;
        return new Vector3(
            center.x + Mathf.Cos(angle) * radius,
            center.y + Mathf.Sin(angle) * radius,
            center.z
        );
    }
}
