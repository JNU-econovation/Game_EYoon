using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_SatelliteMonster : Enemy_UFO_bullet
{
    GameObject player;
    Enemy_SatelliteBulletRotater Rotater;

    float distance;
    // Start is called before the first frame update
    void Start()
    {
        Rotater = GetComponentInChildren<Enemy_SatelliteBulletRotater>();
        player = LevelManager.Instance.GetPlayer();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, -speed, 0);
        isPaused = EnemyManager.Instance.isPause;
        if (isPaused == true)
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
