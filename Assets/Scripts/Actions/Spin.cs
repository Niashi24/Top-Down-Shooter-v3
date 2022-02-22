using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spin : MonoBehaviour
{
    [SerializeField, Tooltip("Degrees Per Second")] float _DPS;
    [SerializeField] bool _clockwise;

    void Update() {
        transform.eulerAngles = new Vector3(
            transform.eulerAngles.x,
            transform.eulerAngles.y,
            transform.eulerAngles.z + _DPS * Time.deltaTime * (_clockwise ? 1 : -1)
        );
    }
}
