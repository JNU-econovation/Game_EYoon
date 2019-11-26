using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_SpaceShuttle : Enemy
{
    float enemyPos;
    int direction;
    GameObject player;
    Quaternion quaternion = Quaternion.Euler(0, 180f, 0);
   

    // Start is called before the first frame update
    void Start()
    {
        player = LevelManager.Instance.GetPlayer();
        SetPosition();
    }

    // Update is called once per frame
    void Update()
    {
        if (isPaused)
            speed = 0;
        else if (isPaused == false)
            speed = originSpeed;

        transform.Translate(0, speed, 0);
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
        enemyPos = 600 + Random.Range(50, 500);
        float enemyPos1 = 50 + Random.Range(400, 800);
        if (dir <= 20)
        {
            transform.position = new Vector2(-224, enemyPos + playerHeight);
            transform.rotation = Quaternion.Euler(0, 0, 270);
        }
        else if (20 < dir && dir <= 40)
        {
            transform.position = new Vector2(-224, enemyPos + playerHeight);
            transform.rotation = Quaternion.Euler(0, 0, 225);
        }
        else if (40 < dir && dir <= 60)
        {
            transform.position = new Vector2(Random.Range(135, 576), 1100 + playerHeight);
            transform.rotation = Quaternion.Euler(0, 0, 180);
        }
        else if (60 < dir && dir <= 80)
        {
            transform.position = new Vector2(957, enemyPos + playerHeight);
            transform.rotation = Quaternion.Euler(0, 0, 135);
        }
        else if (80 < dir && dir <= 100)
        {
            transform.position = new Vector2(957, enemyPos + playerHeight);
            transform.rotation = Quaternion.Euler(0, 0, 90);
        }
    }
}
