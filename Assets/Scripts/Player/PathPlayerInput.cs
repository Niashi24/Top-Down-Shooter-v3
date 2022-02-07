using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class PathPlayerInput : PlayerMovementInput
{
    [SerializeField] Vector2[] moves;

    const float minDistance = 0.1f;

    [ShowInInspector, ReadOnly]
    private int currentIndex;
    [ShowInInspector, ReadOnly]
    private Vector2 currentTarget;

    void Awake() {
        if (moves.Length == 0)
            currentTarget = transform.position;
        else
            currentTarget = (Vector2)transform.position + moves[0];
    }

    void OnDrawGizmosSelected() {
        if (moves == null) return;
        var position = transform.position;
        foreach(var move in moves) {
            Debug.DrawLine(position, position += (Vector3)move, Color.green);
        }    
    }

    public override Vector2 Direction {get{
        if (Vector2.Distance(transform.position, currentTarget) < minDistance) {
            currentIndex++;
            if (currentIndex >= moves.Length) currentIndex = 0;

            currentTarget = (Vector2)transform.position + moves[currentIndex];
        }

        //Debug.Log((currentTarget - (Vector2)transform.position).normalized);

        return (currentTarget - (Vector2)transform.position).normalized;
    }}
}
