using System.Collections.Generic;
using UnityEngine;
using System.Linq;

[System.Serializable]
public class WeightedRandomClass<T>
{
    [SerializeField]
    List<TypePair<int, T>> items;

    public WeightedRandomClass(IEnumerable<TypePair<int, T>> items) {
        this.items = items.ToList();
    }

    public void Init(IEnumerable<TypePair<int, T>> items) {
        this.items = items.ToList();
    }

    public void Remove(T key) {
        int index = items.FindIndex(x => x.Value2.Equals(key));
        items.RemoveAt(index);
    }

    public bool Empty => items.Count == 0;

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
        if (Empty) return default;
        
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