using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Sky_Eagle : Enemy
{
    [SerializeField] GameObject bullet;
    [SerializeField] int bulletCount;
    GameObject player;
    Animator animator;
    bool isAttack;
    bool isMade;
    bool attack;
    float distance_y;
    float time = 0;
    float stopPos; //몬스터가 플래이어로부터 멈추는 거리
    void Start()
    {
        damage = GetComponent<Enemy_Ability>().GetDamage();
        animator = GetComponent<Animator>();
        player = LevelManager.Instance.GetPlayer();
        SetPosition();
        StartCoroutine(Attack());
    }

    IEnumerator Attack()
    {
        while (true)
        {
            if (isPaused == false)
            {
                yield return null;
                if (time >= 3.0f)
                {
                    time = 0;
                    if (isAttack)
                    {
                        isAttack = false;
                        animator.SetBool("IsAttack", false);
                    }

                    else
                    {
                        float distance_x = transform.position.x - player.transform.position.x;
                        float angle = Mathf.Atan2(distance_x, distance_y) * Mathf.Rad2Deg;
                        Enemy_AttackPattern.Instance.SingleShot(gameObject, bullet, angle, damage);
                        animator.SetBool("IsAttack", true);
                        isAttack = true;
                    }
                }
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (isPaused)
        {
            speed = 0;
            DestroyControll();
        }
        else if (isPaused == false)
            speed = originSpeed;
        distance_y = transform.position.y - player.transform.position.y;
        if (distance_y < stopPos)
        {
            speed = 0;
            if (attack == false)
            {

                StartCoroutine(Attack());
            }
            if (transform.position.x < 96 || transform.position.x > 631)
            {
                speed_x = speed_x * -1;
                originSpeed_x = speed_x;
            }
            transform.Translate(speed_x, 0, 0);

        }
        transform.Translate(speed, -speed, 0);
       
    }
    public override void Pause()
    {
        isPaused = true;
        savedNum = num;
    }

    public override void Resume()
    {
        isPaused = false;
    }

    public override void SetPosition()
    {
        float dir = Random.Range(135, 576);
        float ypos = player.transform.position.y + 1000;
        transform.position = new Vector3(-100, ypos, 0);

    }
    
}
