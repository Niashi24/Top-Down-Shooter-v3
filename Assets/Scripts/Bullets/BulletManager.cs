using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManager : MonoBehaviour
{
    [SerializeField]
    List<BulletScript> bullets;

    [SerializeField] ShotType _type;
    public ShotType ShotType => _type;

    [SerializeField] float _maxTime;

    public event Action<BulletManager> OnShoot;

    private float timer;

    public void SetStats(PlayerStats stats)
    {
        stats.SetDamage((int)(stats.Damage * _type.damageMultiplier));
        bullets.ForEach(x => x.SetStats(stats));
    }

    void Start() {
        OnShoot?.Invoke(this);
    }

    [Sirenix.OdinInspector.Button]
    public void GetBullets() {
        bullets = new List<BulletScript>(GetComponentsInChildren<BulletScript>());
    }

    void Update() {
        timer += Time.deltaTime;
        if (timer > _maxTime)
            Destroy(gameObject);    
    }
}
