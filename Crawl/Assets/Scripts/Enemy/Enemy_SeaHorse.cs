using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_SeaHorse : Enemy
{
    GameObject player;
    [SerializeField] GameObject bullet;
    [SerializeField] int bulletCount;
    float sideMoveCycle; // 좌우 이동 변경 주기
    float stopPos; //몬스터가 플래이어로부터 멈추는 거리
    float distance_y;
    [SerializeField] float attackDelay;
    bool attack;
    bool sideMove = false;

    private void Start()
    {

        player = LevelManager.Instance.GetPlayer();
        damage = GetComponent<Enemy_Ability>().GetDamage();
        stopPos = Random.Range(400, 750);
        SetPosition();
    }
    private void Update()
    {

        if (isPaused)
        {
            speed = 0;
            speed_x = 0;
        }
        else if (isPaused == false)
        {
            speed = originSpeed;
            speed_x = originSpeed_x;
        }
        //print(isPaused);

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
        transform.Translate(0, -speed, 0);
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
        int dir = Random.Range(135, 576);
        float ypos = player.transform.position.y + 1000;
        transform.position = new Vector3(dir, ypos, 0);
    }

    IEnumerator Attack()
    {
        if (isPaused == false)
        {
            attack = true;
            float distance_x = transform.position.x - player.transform.position.x;
            float angle = Mathf.Atan2(distance_x, distance_y) * Mathf.Rad2Deg;
            Enemy_AttackPattern.Instance.MultiShot(gameObject, bullet, bulletCount, damage);
            yield return new WaitForSeconds(attackDelay);
            attack = false;
        }
    }
    
}
