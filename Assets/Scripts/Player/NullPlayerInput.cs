using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NullPlayerInput : PlayerInput
{
    public override bool Shoot => false;

    public override Vector2 Direction => Vector2.zero;
}
