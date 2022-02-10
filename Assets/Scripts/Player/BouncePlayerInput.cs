using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

public class BouncePlayerInput : PlayerMovementInput
{
    [SerializeField] Vector2 _xRange = new Vector2(-5, 5);
    [ShowInInspector, ReadOnly]
    bool movingRight;

    void Start() {
        movingRight = Random.value > 0.5f;
    }

    bool HitRightEdge => transform.position.x > _xRange.y;
    bool HitLeftEdge => transform.position.x < _xRange.x;

    public override Vector2 Direction {get {

        if (movingRight) {
            if (HitRightEdge) {
                movingRight = false;
                return Vector2.left;
            }
            return Vector2.right;
        } else {
            if (HitLeftEdge.Log(this)) {    
                movingRight = true;
                return Vector2.right;
            }
            return Vector2.left;
        }
    }}
}
