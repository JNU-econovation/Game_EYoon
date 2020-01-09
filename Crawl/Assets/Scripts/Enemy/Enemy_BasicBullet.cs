using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_BasicBullet : Enemy_UFO_bullet
{
     void Update()
    {
        transform.Translate(0, -speed, 0);
        isPaused = EnemyManager.Instance.isPause;
        if (isPaused)
        {
            speed = 0;
        }
        else
        {
            time += Time.deltaTime;
            speed = originSpeed;
        }
    }

}
