using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Shot Types/One Shot")]
public class OneShot : BaseShot
{
    [SerializeField] GameObject _bullet;
    public override void Fire(PlayerShoot shoot)
    {
        Instantiate(_bullet, shoot.transform.position, Quaternion.identity);
    }
}
