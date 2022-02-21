using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

public class PlayerBounceInput : PlayerMovementInput
{
    [SerializeField] Vector2 _xRange;
    [SerializeField] Vector2 _yRange;
    [SerializeField] Transform _center;

    [ShowInInspector, ReadOnly]
    Vector2 currentDirection;

    void Start() {
        //would love to not use findobjectoftype here but
        //the game is basically done at this point so whatev
        if (_center == null)
            _center = FindObjectOfType<PathManager>().transform;
        
        currentDirection = new Vector2(
            Random.value < 0.5f ? -1 : 1,
            -1
        ); 
    }

    public override Vector2 direction {get {
        if (HitRightEdge)
            currentDirection.x = -1;
        if (HitLeftEdge)
            currentDirection.x = 1;
        if (HitTopEdge)
            currentDirection.y = -1;
        if (HitBottomEdge)
            currentDirection.y = 1;

        return default;
    }}

    public bool HitRightEdge => transform.position.x > _xRange.y + _center.transform.position.x;
    public bool HitLeftEdge => transform.position.x < _xRange.x + _center.transform.position.x;
    public bool HitTopEdge => transform.position.y > _yRange.y + _center.transform.position.y;
    public bool HitBottomEdge => transform.position.y < _yRange.x + _center.transform.position.y;
}
