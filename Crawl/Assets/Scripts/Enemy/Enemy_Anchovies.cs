using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Anchovies : Enemy
{
    int direction;
    bool attack = false;
    GameObject player;
    // Start is called before the first frame update
    private void Start()
    {
        player = LevelManager.Instance.GetPlayer();
        //player = GameObject.FindGameObjectWithTag("Player");
        SetPosition();
        originSpeed = speed;
        damage = 0;
        player = LevelManager.Instance.GetPlayer();
        // 아직 getPlayer에서 현재 게임 플래이 중인 플래이어를 불러올수 없어 오류가생겨요
    }
    private void Update()
    {
        if (isPaused)
            speed = 0;
        else if (isPaused == false)
            speed = originSpeed;
        transform.Translate(speed * direction, 0, 0);

        if (transform.position.x < -300 || transform.position.x > 811)
        {
            Destroy(gameObject);
        }
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
        int pos_y = 500 + Random.Range(0, 200);
        float playerHeight = player.transform.position.y;
        if (dir <= 50)
        {
            transform.position = new Vector2(796, pos_y + playerHeight);
            direction = -1;
        }
        else if (50 < dir && dir <= 100)
        {
            transform.rotation = Quaternion.Euler(0,180,0);
            transform.position = new Vector2(-281, pos_y + playerHeight);
            direction = 1;
        }
    }
}
