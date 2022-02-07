using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserInput : PlayerInput
{
    [SerializeField] InputSettings _input;

    public override Vector2 Direction {get {
        int x = 0;
        if (Input.GetKey(_input.Right))
            x++;
        if (Input.GetKey(_input.Left))
            x--;
        
        int y = 0;
        if (Input.GetKey(_input.Up))
            y++;
        if (Input.GetKey(_input.Down))
            y--;

        return new Vector2(x,y);
    }}

    public override bool Shoot => Input.GetKey(_input.Confirm);
}
