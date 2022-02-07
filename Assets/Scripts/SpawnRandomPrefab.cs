using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnRandomPrefab : MonoBehaviour
{
    [SerializeField] WeightedGameObject _randomObjects;

    public void SpawnPrefab() 
    {
        Instantiate(
            _randomObjects.GetRandom(), 
            transform.position, 
            Quaternion.identity
        );
    }
}
