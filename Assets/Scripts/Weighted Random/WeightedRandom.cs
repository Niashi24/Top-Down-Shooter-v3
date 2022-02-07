using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeightedRandom<T> : ScriptableObject
{
    [SerializeField]
    List<TypePair<int, T>> items;

    public T GetRandom() {
        return GetRandomWithWeights(GetWeights(items), items);
    }

    float[] GetWeights(List<TypePair<int, T>> items) {
        int sum = 0;
        for (int i = 0; i < items.Count; i++) {
            sum += items[i].Value1;
        }

        float[] weights = new float[items.Count];
        for (int i = 0; i < weights.Length; i++) {
            weights[i] = items[i].Value1 / (float)sum;
        }

        return weights;
    }

    T GetRandomWithWeights(float[] weights, List<TypePair<int, T>> items) {

        var random = RandomValue();
        float sum = 0;
        for (int i = 0; i < weights.Length; i++) {
            sum += weights[i];
            if (random < sum)
                return items[i].Value2;
        }
        return items[items.Count - 1].Value2;
    }

    public virtual float RandomValue() => Random.value;
}
