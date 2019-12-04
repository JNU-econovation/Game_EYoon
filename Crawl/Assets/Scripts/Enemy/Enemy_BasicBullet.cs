using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_BasicBullet : Enemy_UFO_bullet
{
     void Update()
    {
        transform.Translate(0, -speed, 0);
        if (isPaused == true)
        {
            time = presentTime ;
        }
    }
    public override void Resume()
    {
        speed = originSpeed;
        isPaused = false;
    }

    public override void Stop()
    {
        speed = 0;
        presentTime = time;
        isPaused = true;
    }
}
