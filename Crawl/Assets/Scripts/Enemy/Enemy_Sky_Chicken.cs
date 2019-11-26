using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Sky_Chicken : Enemy
{
    GameObject player;
    void Start()
    {
        player = LevelManager.Instance.GetPlayer();
        SetPosition();
    }
    
    void Update()
    {
        if (isPaused)
            speed = 0;
        else if (isPaused == false)
            speed = originSpeed;
        transform.Translate(0, -speed, 0);      
    }

    public override void Pause()
    {

    }

    public override void Resume()
    {

    }

    public override void SetPosition()
    {
        float dir = Random.Range(135, 576);
        float ypos = player.transform.position.y + 1000;
        transform.position = new Vector3(dir, ypos, 0);
    }
    
}
