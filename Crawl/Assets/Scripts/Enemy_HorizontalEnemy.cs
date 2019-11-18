using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_HorizontalEnemy : Enemy
{
    float enemyPos;
    int direction;
    GameObject player;
    Quaternion quaternion = Quaternion.Euler(0, 180f, 0);
    private void Start()
    {
        originSpeed = speed;
        player = LevelManager.Instance.GetPlayer();
        SetPosition();
    }
    private void Update()
    {
        if (isPaused)
            speed = 0;
        else if (isPaused == false)
            speed = originSpeed;

        transform.Translate(speed * direction,0,0);
    }

   
    public override void Pause()
    {
        isPaused = true;
    }
    public override void Resume()
    {
        isPaused = false;
    }


    public override void SetPosition()
    {
        int dir = Random.Range(0, 100);
        
        float playerHeight = player.transform.position.y;
        enemyPos = 50+ Random.Range(50, 800);

        if (dir <= 50)
        {
            transform.position = new Vector2(957, enemyPos + playerHeight);
            direction = -1;
        }
        else if ( 50 < dir && dir <= 100)
        {
            GetComponent<SpriteRenderer>().flipX = true;
            transform.position = new Vector2(-224, enemyPos + playerHeight);
            direction = 1;
        }
    }
    
}
