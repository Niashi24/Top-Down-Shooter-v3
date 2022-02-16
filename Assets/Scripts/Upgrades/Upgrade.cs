using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Upgrade : ScriptableObject
{
    [SerializeField]
    PlayerStats _stats;
    public PlayerStats Stats => _stats;

    [SerializeField]
    BulletManager _bulletPrefab;
    public BulletManager BulletPrefab => _bulletPrefab;
}
