using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityAtoms.BaseAtoms;

public class ActivateActionOnStart : MonoBehaviour
{
    [SerializeField] List<GameObjectAction> _actions;
    void Start() {
        _actions.ForEach(action => action.Do(gameObject));    
    }
}
