using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

public class RandomPool<T> : RandomSupplier<T>
{
    [SerializeField]
    List<TypePair<int, T>> weights;

    private List<T> pool;

    [ShowInInspector, ReadOnly]
    private List<int> numberOfEachItem;

    public void Reset() {
        pool = new List<T>();
        foreach(var item in weights) {
            for (int i = 0; i < item.Value1; i++) {
                pool.Add(item.Value2);
            }
        }
    }

    void OnEnable() {
        Reset(); 
        numberOfEachItem = new List<int>(weights.Map(x => x.Value1));    
    }

    public override T GetRandom() {
        int index = (int)(RandomValue() * pool.Count);
        
        var random = pool[index];
        pool.RemoveAt(index);

        return random;
    }

    public virtual float RandomValue() => Random.value;
}
