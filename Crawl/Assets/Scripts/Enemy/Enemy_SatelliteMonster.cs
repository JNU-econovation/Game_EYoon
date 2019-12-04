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
        if (isPaused == true)
        {
            time = presentTime;
        }
    }


    public override void Resume()
    {
        isPaused = false;
        speed = originSpeed;
        Rotater.Resume();
    }



    public override void Stop()
    {
        speed = 0;
        presentTime = time;
        Rotater.Stop();
    }
}
