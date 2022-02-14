using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resetter : MonoBehaviour
{
    [SerializeField] List<GenericReference<IResettable>> Resettables;

    [SerializeField] bool resetOnStart = false;

    void Start() {
        if (resetOnStart)
            ResetVariables();
    }

    public void ResetVariables() {
        Resettables.ForEach(item =>
            item.Value?.Reset()
        );
    }
}
