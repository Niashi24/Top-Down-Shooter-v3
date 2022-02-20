using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnShootPlaySound : MonoBehaviour
{
    [SerializeField] BulletManager _bulletManager;

    [SerializeField, Range(0,2)] float _minPitch;
    [SerializeField, Range(0,2)] float _maxPitch;

    [SerializeField] AudioSource _source;
    
    void OnEnable() {
        _bulletManager.OnShoot += PlayShootSource;
    }
    
    void OnDisable() {
        _bulletManager.OnShoot -= PlayShootSource;
    }
    
    void PlayShootSource(BulletManager bullet) {
        _source.pitch = Random.Range(_minPitch, _maxPitch);
        _source.PlayOneShot(bullet.ShotType.ShootSFX);
    }
}
