using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerMovementInput : MonoBehaviour
{
    public Vector2 Direction =>
        enabled ? direction : Vector2.zero;

    public abstract Vector2 direction {get;}
}
