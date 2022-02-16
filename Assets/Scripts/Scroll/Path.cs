using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using System.Linq;

public class Path : MonoBehaviour
{
    [SerializeField] float _speed;
    [SerializeField] List<Vector2> moves;
    
    [SerializeField] List<Transform> targets;

    void OnDrawGizmos() {
        targets = targets.Where(x => x != null).ToList();
        if (moves == null) return;
        foreach (var mono in targets) {
            Vector3 position = mono.transform.position;
            foreach (var move in moves) {
                Debug.DrawLine(position, position + (Vector3)move, Color.green);
                position += (Vector3)move;
            }
        }
        Vector3 pos = transform.position;
        foreach (var move in moves) {
            Debug.DrawLine(pos, pos + (Vector3)move, Color.green);
            pos += (Vector3)move;
        }
    }

    [Button]
    public void StartMove() {
        StartCoroutine(MoveOverTime());
    }

    IEnumerator MoveOverTime() {
        foreach(var move in moves) {
            var target = move + (Vector2)transform.position;
            
            while (Vector2.Distance(transform.position, target) > 0) {

                var newPosition = Vector2.MoveTowards(transform.position, target, _speed * Time.deltaTime);
                var displacement = newPosition - (Vector2)transform.position;
                transform.position = new Vector3(newPosition.x, newPosition.y, transform.position.z);
                targets.ForEach(x => x.position += (Vector3)displacement);

                yield return null;
            }
        }
    }
}
