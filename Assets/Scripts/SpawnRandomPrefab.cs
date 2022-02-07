using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnRandomPrefab : MonoBehaviour
{
    [SerializeField] WeightedGameObject _randomObjects;
    [SerializeField, Range(0, 1)] float _chance = 1;

    public void SpawnPrefab() 
    {
        if (Random.value <= _chance) return;
        var random = _randomObjects.GetRandom();
        
        Instantiate(
            random,
            transform.position, 
            Quaternion.identity
        );
    }
}
