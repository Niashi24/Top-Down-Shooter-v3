using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityAtoms.BaseAtoms;

[CreateAssetMenu]
public class DisableIfAction : GameObjectAction
{
    [SerializeField] BoolReference enable;
    public override void Do(GameObject obj) {
        obj.SetActive(!enable.Value);
    }
}
