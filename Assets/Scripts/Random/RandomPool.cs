using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

public class RandomPool<T> : RandomSupplier<T>
{
    [SerializeField]
    List<TypePair<int, T>> weights;

    [ShowInInspector, ReadOnly]
    private List<int> numberOfEachItem;

    void OnEnable() {
        numberOfEachItem = new List<int>(weights.Map(x => x.Value1));    
    }

    public override T GetRandom() {
        var index = GetRandomIndexWithWeights(GetWeights(numberOfEachItem));
        return weights[index].Value2;
    }

    float[] GetWeights(List<int> weights) {
        int sum = 0;
        for (int i = 0; i < this.weights.Count; i++) {
            sum += weights[i];
        }

        float[] floatWeights = new float[weights.Count];
        for (int i = 0; i < floatWeights.Length; i++) {
            floatWeights[i] = weights[i] / (float)sum;
        }

        return floatWeights;
    }

    int GetRandomIndexWithWeights(float[] weights) {
        var random = RandomValue();
        float sum = 0;
        for (int i =0 ;i < weights.Length; i++) {
            sum += weights[i];
            if (random < sum)
                return i;
        }
        return weights.Length - 1;
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
