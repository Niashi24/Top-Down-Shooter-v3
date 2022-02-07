using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAlongPoints : MonoBehaviour
{
    [SerializeField] List<Vector2> points;

    void OnDrawGizmos() {
        if (points == null) return;

        for (int i = 0; i < points.Count - 1; i++) {
            Debug.DrawLine(points[i], points[i+1]);
        }    
    }
}
