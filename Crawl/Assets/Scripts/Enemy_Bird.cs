using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Bird : Enemy
{
    float birdPos;
    int direction;
    [SerializeField] Animator[] species;
    GameObject player;
    Quaternion quaternion = Quaternion.Euler(0, 180f, 0);
    private void Start()
    {
        originSpeed = speed;
        player = LevelManager.Instance.GetPlayer();
        SelectSpecies();
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
        birdPos =300+ Random.Range(0, 200);

        if (dir <= 50)
        {
            GetComponent<SpriteRenderer>().flipX = true;
            transform.position = new Vector2(796, birdPos + playerHeight);
            direction = -1;
        }
        else if ( 50 < dir && dir <= 100)
        {
            transform.position = new Vector2(-76, birdPos + playerHeight);
            direction = 1;
        }
    }
    void SelectSpecies()
    {
        int rand = Random.Range(1, 4);
        print(rand);
        GetComponent<Animator>().SetInteger("Species", rand);
    }
}
