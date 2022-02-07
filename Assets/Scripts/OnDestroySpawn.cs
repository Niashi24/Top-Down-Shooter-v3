using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnDestroySpawn : MonoBehaviour
{
    [SerializeField] GameObject _objectPrefab;

    void OnDestroy() {
        Debug.Log($"{gameObject.name}");
        //Instantiate(_objectPrefab, transform.position, Quaternion.identity);
    }
}
