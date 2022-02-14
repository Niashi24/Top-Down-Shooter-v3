using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

public class RandomPool<T> : RandomSupplier<T>, IResettable
{
    [SerializeField]
    List<TypePair<int, T>> _objectPool;

    private List<T> pool;

    public void Reset() {
        pool = new List<T>();
        foreach(var item in _objectPool) {
            for (int i = 0; i < item.Value1; i++) {
                pool.Add(item.Value2);
            }
        }
    }

    void OnEnable() {
        Reset();   
    }

    public override T GetRandom() {
        if (pool.Count == 0) return default;

        int index = (int)(RandomValue() * pool.Count);
        
        var random = pool[index];
        pool.RemoveAt(index);

        return random;
    }

    public virtual float RandomValue() => Random.value;
}
