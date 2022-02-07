using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerShootInput : PlayerShootInput
{
    [SerializeField] float timeToShoot;
    private float timer;

    public override bool Shoot {get{
        if (timer > timeToShoot) {
            timer = 0;
            return true;
        }
        return false;
    }}

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
    }
}
