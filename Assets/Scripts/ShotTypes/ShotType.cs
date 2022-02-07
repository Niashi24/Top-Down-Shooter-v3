using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class ShotType : ScriptableObject
{
    public float damageMultiplier = 1;

    [SerializeField] AudioClip _shootSFX;
    public AudioClip ShootSFX => _shootSFX;
    [SerializeField] AudioClip _hitSFX;
    public AudioClip HitSFX => _hitSFX;
}
