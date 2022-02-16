using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using System.Linq;
using UnityAtoms.BaseAtoms;

public class PathManager : MonoBehaviour
{
    [SerializeField] float _speed;
    [SerializeField] float _distance = 1000;
    [SerializeField] List<Transform> targets;

    [SerializeField] FloatReference _currentProgress;

    [Button]
    public void StartMove() {
        StartCoroutine(MoveOverTime());
    }

    void OnDrawGizmos() {
        Debug.DrawLine(transform.position, transform.position + Vector3.up * _distance, Color.green);    
    }

    IEnumerator MoveOverTime() {
        var target = Vector2.up * _distance + (Vector2)transform.position;
        
        while (Vector2.Distance(transform.position, target) > 0) {
            var newPosition = Vector2.MoveTowards(transform.position, target, _speed * Time.deltaTime);
            var displacement = newPosition - (Vector2)transform.position;

            transform.position = new Vector3(newPosition.x, newPosition.y, transform.position.z);
            targets.RemoveNull();
            targets.ForEach(x => {if(x != null) x.position += (Vector3)displacement;});

            _currentProgress.Value = 1f - Vector2.Distance(transform.position, target) / _distance;

            yield return null;
        }
    }
}
