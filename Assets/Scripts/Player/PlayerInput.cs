using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public abstract class PlayerInput : MonoBehaviour
{
    public abstract bool Shoot {get;}

    public abstract Vector2 Direction {get;}
}
