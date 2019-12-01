using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_BasicBullet : Enemy_UFO_bullet
{
    public override void Resume()
    {
        speed = originSpeed;
    }

    public override void Stop()
    {
        speed = 0;
    }
}
