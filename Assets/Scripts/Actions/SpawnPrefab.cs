using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPrefab : MonoBehaviour
{
    [SerializeField] GameObject _objectPrefab;

    public void Spawn() {
        Instantiate(_objectPrefab, transform.position, Quaternion.identity);
    }
}
