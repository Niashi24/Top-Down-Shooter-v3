using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeRandomPool<TValue> : RandomSupplier<TValue>
{
    [SerializeField]
    List<UpgradePoolObject<TValue>> initialObjects;

    private List<UpgradePoolObject<TValue>> currentObjects;
    
    private WeightedRandom<TValue> random;

    void OnEnable() {
        currentObjects = new List<UpgradePoolObject<TValue>>(initialObjects);
        random = new WeightedRandom<TValue>(
            currentObjects.Map((x) => new TypePair<int, TValue>(x.weight, x.Value))
        );
    }

    public override TValue GetRandom()
    {
        //get a random object
        TValue randomObject = random.GetRandom();
        //if that object's upgrade level is maxed
        //remove the object's upgrade from the list and get another object
        currentObjects.Find(x => x.Value.Equals(randomObject));

        throw new System.NotImplementedException();
    }
}
