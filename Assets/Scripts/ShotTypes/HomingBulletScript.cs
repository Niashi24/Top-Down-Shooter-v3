using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class HomingBulletScript : BulletScript
{
    [SerializeField] float _homingRadius = 5;
    [SerializeField] float _homingForce = 5;

    [SerializeField] LayerMask _targetMask;
    protected override void ChangeDirection() {
        //get close objects
        var targets = Physics2D.OverlapCircleAll(transform.position, _homingRadius, _targetMask);
        //get closest object
        var target = targets
            .Where(x => !x.CompareTag(Tags.Bullet))
            .OrderBy((x) => Vector2.Distance(transform.position, x.transform.position))
            .FirstOrDefault();
        if (target == null) return;

        Vector2 displacement = target.transform.position - transform.position;

        velocity = (displacement.normalized * _homingForce + velocity).normalized * velocity.magnitude;

        //velocity = velocity.RotateTowards(displacement, _angleChange * Time.deltaTime);
    }

    void OnDrawGizmosSelected() {
        Gizmos.DrawWireSphere(transform.position, _homingRadius);    
    }
}
