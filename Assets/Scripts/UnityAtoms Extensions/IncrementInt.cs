using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityAtoms.BaseAtoms;

public class IncrementInt : MonoBehaviour
{
    [SerializeField] IntReference _int;

    public void Do(int t1)
    {
        _int.Value += t1;
    }
}
