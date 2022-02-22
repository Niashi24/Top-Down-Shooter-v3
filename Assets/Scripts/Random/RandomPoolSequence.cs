using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public abstract class RandomPoolSequence<T> : RandomSupplier<T>, IResettable
{
    [SerializeField, InlineEditor]
    RandomPool<T>[] _pools;

    int currentPoolIndex = 0;
    [ShowInInspector, ReadOnly, InlineEditor]
    RandomPool<T> currentPool;

    void OnEnable() {
        Reset();
    }

    public override T GetRandom()
    {
        if (currentPool == null) return DefaultObject;
        var element = currentPool.GetRandom();
        if (currentPool.Empty)
            Increment();
        if (element == null)
            return DefaultObject;

        return element;
    }

    void Increment()
    {
        currentPoolIndex++;
        UpdatePool();
    }

    private void UpdatePool()
    {
        if (currentPoolIndex >= _pools.Length)
        {
            currentPool = null;
        }
        else
        {
            currentPool = _pools[currentPoolIndex];
        }
    }

    public void Reset()
    {
        currentPoolIndex = 0;
        UpdatePool();
    }

    protected virtual T DefaultObject => default;
}
