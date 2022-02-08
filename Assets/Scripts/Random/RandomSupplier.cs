using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class RandomSupplier<T> : ScriptableObject
{
    public abstract T GetRandom();   
}