using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Sky_Pigeon : Enemy
{
    GameObject player;
    void Start()
    {
        player = LevelManager.Instance.GetPlayer();
        SetPosition();
    }

    // Update is called once per frame
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
        transform.Translate(speed, 0, 0);
    }


    public override void SetPosition()
    {
        float ypos = player.transform.position.y + Random.Range(100, 700);
        int xpos = Random.Range(0, 2);
        if (xpos == 0)
        {
            transform.rotation = new Quaternion(0, 0, 0, 0);
            transform.position = new Vector3(-100, ypos, 0);
        }
        else
        {
            transform.rotation = new Quaternion(0, 1, 0, 0);
            transform.position = new Vector3(820, ypos, 0);
        }

    }
    
}
