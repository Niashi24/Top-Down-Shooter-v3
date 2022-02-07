using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LerpBetween2Transforms : MonoBehaviour
{
    [SerializeField] Transform _targetObject;
    [SerializeField] Transform _startLocation;
    [SerializeField] Transform _endLocation;
    [SerializeField] GenericReference<ITest> test;

    public void LerpBetween(float t) {
        _targetObject.position = Vector3.Lerp(
            _startLocation.position,
            _endLocation.position,
            t
        );    
    }
}
