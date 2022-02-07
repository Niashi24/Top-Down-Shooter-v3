using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompositePlayerInput : PlayerInput
{
    [SerializeField] PlayerShootInput _shootInput;
    [SerializeField] PlayerMovementInput _movementInput;


    public override bool Shoot => _shootInput ? _shootInput.Shoot : false;

    public override Vector2 Direction => _movementInput ? _movementInput.Direction : Vector2.zero;
}
