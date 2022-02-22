using System.Collections;
using System.Collections.Generic;
using UnityAtoms.BaseAtoms;
using UnityEngine;

public class SpawnRandomPrefab : MonoBehaviour
{
    [SerializeField] RandomSupplier<GameObject> _randomObjects;
    [SerializeField] FloatReference _chance = new FloatReference(1);

    public void SpawnPrefab() 
    {
        if (Random.value > _chance.Value) return;
        var random = _randomObjects.GetRandom();
        if (random == null) return;
        
        Instantiate(
            random,
            transform.position, 
            Quaternion.identity
        );
    }
}
