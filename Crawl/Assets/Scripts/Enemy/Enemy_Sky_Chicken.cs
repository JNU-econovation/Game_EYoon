using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Sky_Chicken : Enemy
{
    GameObject player;
    void Start()
    {
        originSpeed = speed;
        player = LevelManager.Instance.GetPlayer();
        SetPosition();
    }
    
    void Update()
    {
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
        transform.Translate(0, -speed, 0);      
    }



    public override void SetPosition()
    {
        float dir = Random.Range(135, 576);
        float ypos = player.transform.position.y + 1000;
        transform.position = new Vector3(dir, ypos, 0);
    }
    
}
