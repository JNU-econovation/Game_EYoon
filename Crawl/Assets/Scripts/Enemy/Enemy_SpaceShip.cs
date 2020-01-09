using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_SpaceShip : Enemy
{
    float enemyPos;
    int direction;
    GameObject player;
    Quaternion quaternion = Quaternion.Euler(0, 180f, 0);
    float distance_y;
    [SerializeField] float firePos;
    bool attack;
    bool turn = false;
    [SerializeField] GameObject bullet;
    // Start is called before the first frame update
    void Start()
    {
        player = LevelManager.Instance.GetPlayer();
        SetPosition();
        
    }

    // Update is called once per frame
    void Update()
    {
        distance_y = transform.position.y - player.transform.position.y;
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

        if (distance_y < firePos)
        {
            if (attack == false)
                Attack();

            if (turn == false)
            {
                if (transform.position.x < 360)
                    transform.rotation = Quaternion.Euler(0, 0, Random.Range(-90, -170));
                else if (transform.position.x >= 360)
                    transform.rotation = Quaternion.Euler(0, 0, Random.Range(90, 170));
                turn = true;
            }


        }
       
            transform.Translate(0, -speed, 0);
        
    }
    void Attack()
    {
        attack = true;
        float distance_x = transform.position.x - player.transform.position.x;
        float angle = Mathf.Atan2(distance_x, distance_y) * Mathf.Rad2Deg;
        Enemy_AttackPattern.Instance.SingleShot(gameObject, bullet, angle, damage);
    }
 

    public override void SetPosition()
    {
        float playerHeight = player.transform.position.y;

        transform.position = new Vector2(Random.Range(135, 576), 1100 + playerHeight);

    }
}
