using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Sky_Eagle : Enemy
{
    float enemyPos;
    int direction;
    GameObject player;
    Quaternion quaternion = Quaternion.Euler(0, 180f, 0);
    float distance_y;
    [SerializeField] float firePos;
    bool attack = false;
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

        if (distance_y < firePos && attack == false && transform.position.x >-110 && transform.position.x<811 )
        {
                StartCoroutine(Attack());
            
        }

        transform.Translate(speed_x, -speed, 0);
   

    }
    IEnumerator Attack()
    {
        attack = true;
        GetComponent<Animator>().SetBool("IsAttack", true);
        float distance_x = transform.position.x - player.transform.position.x;
        float angle = Mathf.Atan2(distance_x, distance_y) * Mathf.Rad2Deg;
        Enemy_AttackPattern.Instance.SingleShot(gameObject, bullet, angle, damage);
        yield return new WaitForSeconds(0.1f);
        GetComponent<Animator>().SetBool("IsAttack", false);
    }


    public override void SetPosition()
    {
        int rand = Random.Range(1, 3);
        float playerHeight = player.transform.position.y;
        if (rand == 1)
        {
            transform.position = new Vector2(-300, Random.Range(1100, 1400) + playerHeight);
        }

        else if (rand == 2)
        {
            transform.position = new Vector2(1020, Random.Range(1100, 1400) + playerHeight);
            speed_x = -speed_x;
            GetComponent<SpriteRenderer>().flipX = true;
        }

    }

}
