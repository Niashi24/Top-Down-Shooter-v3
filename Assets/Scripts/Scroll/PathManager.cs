using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using System.Linq;
using UnityAtoms.BaseAtoms;
using UnityEngine.Events;

public class PathManager : MonoBehaviour
{
    [SerializeField] float _speed;
    [SerializeField] float _distance = 1000;
    [SerializeField] List<Transform> targets;

    [SerializeField] FloatReference _currentProgress;
    [SerializeField] UnityEvent OnFinishPath;

    Coroutine MovingCoroutine;

    [Button]
    public void StartMove() {
        MovingCoroutine = StartCoroutine(MoveOverTime());
    }

    void OnEnable() {
        GameManager.OnStateChange += StopMove;
    }

    void OnDisable() {
        GameManager.OnStateChange -= StopMove;
    }

    public void StopMove(GameState state) {
        if (state == GameState.Game) return;
        if (MovingCoroutine == null) return;
        
        StopCoroutine(MovingCoroutine);
    }

    void OnDrawGizmos() {
        Debug.DrawLine(transform.position, transform.position + Vector3.up * _distance, Color.green);    
    }

    void OnDrawGizmosSelected() {
        foreach (var trans in targets) {
            Gizmos.DrawWireCube(trans.position, Vector3.one);
        }    
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

        OnFinishPath?.Invoke();
    }
}
