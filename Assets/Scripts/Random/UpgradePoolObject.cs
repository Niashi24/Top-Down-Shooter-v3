using Sirenix.OdinInspector;
using UnityEngine;
using UnityAtoms.BaseAtoms;
[System.Serializable]
class UpgradePoolObject<T> {
    public IntReference number;
    public int weight;
    public T Value;
}