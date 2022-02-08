using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Random/Weighted Random/GameObject")]
public class WeightedGameObject : WeightedRandom<GameObject>
{
    public WeightedGameObject(IEnumerable<TypePair<int, GameObject>> items) : base(items)
    {
    }
}
