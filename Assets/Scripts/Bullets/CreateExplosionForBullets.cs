using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateExplosionForBullets : MonoBehaviour
{
    [SerializeField]
    BulletScript _bullet;
    [SerializeField]
    GameObject _explosionPrefab;

    void OnEnable() => _bullet.OnBulletDestroyed += SpawnExplosion;
    void OnDisable() => _bullet.OnBulletDestroyed -= SpawnExplosion;

    void SpawnExplosion(BulletScript bullet) {
        Instantiate(_explosionPrefab, bullet.transform.position, Quaternion.identity);
    }
}
