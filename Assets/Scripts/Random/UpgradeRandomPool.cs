using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class UpgradeRandomPool<TValue> : RandomSupplier<TValue>, IResettable
{
    [SerializeField]
    List<UpgradePoolObject<TValue>> objects;
    
    private WeightedRandomClass<TValue> random;

    void OnEnable() {
        Reset();
    }

    public override TValue GetRandom()
    {
        //get a random object
        TValue randomObject = random.GetRandom();
        if (randomObject == null) return DefaultObject;
        //if that object's upgrade level is maxed
        //remove the object's upgrade from the list and get another object
        var obj = GetUpgradeFromObject(randomObject);
        if (obj.number == UpgradeDrop.MAX_UPGRADE_LEVEL)
        {
            random.Remove(randomObject);
            if (random.Empty)
                return DefaultObject;
            else
                return GetRandom();
        }

        return randomObject;
    }

    UpgradePoolObject<TValue> GetUpgradeFromObject(TValue value) =>
        objects.Find(x => x.Value.Equals(value));

    public void Reset()
    {
        if (objects == null) return;

        random = new WeightedRandomClass<TValue>(
            objects.Map((x) => new TypePair<int, TValue>(x.weight, x.Value))
        );
    }

    public virtual TValue DefaultObject => default;
}