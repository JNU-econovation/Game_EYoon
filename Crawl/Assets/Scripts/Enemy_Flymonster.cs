using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Flymonster : Enemy
{
    GameObject player;
    [SerializeField] float downSpeed;
    [SerializeField] GameObject bullet;
    [SerializeField] float sideMoveCycle; // 좌우 이동 변경 주기
    float damage;
    float speed;
    float originSpeed;
    float originSpeed_x;
    float stopPos; //몬스터가 플래이어로부터 멈추는 거리
    float distance_y;
    [SerializeField]float attackDelay;
    bool attack;
    [SerializeField] float speed_x; // 정지 후 좌우로 움직이는 속도
    bool sideMove = false;
    bool isPause = false;

    private void Start()
    {
        originSpeed_x = speed_x;
        originSpeed = speed;
        player = GameObject.FindGameObjectWithTag("Player");
        damage = GetComponent<Enemy_Ability>().GetDamage();
        stopPos = Random.Range(400, 750);
        speed = -downSpeed;
        SetPosition();
    }
    private void Update()
    {
        distance_y = transform.position.y - player.transform.position.y;
        if(distance_y < stopPos)
        {
            speed = 0;
            if (attack == false)
            {
                StartCoroutine(Attack());
            }
            if(transform.position.x < 96 || transform.position.x > 631)
            {
                speed_x = speed_x * -1;
            }
            transform.Translate(speed_x,0,0);
           
        }
        //else if(distance_y <= stopPos)
        //{
        //    speed = Player_AbilityManager.Instance.GetMoveSpeed();
        //}
        

        transform.Translate(0, speed, 0);
    }
    public override void Function()
    {
        
    }
    public override void Pause()
    {
        speed_x = 0;
        isPause = true;
        speed = 0;
    }
    public override void Resume()
    {
        speed_x = originSpeed_x;
        speed = originSpeed;
        isPause = false;
    }

    public override void SetPosition()
    {
        int dir = Random.Range(135, 576);
        float ypos = player.transform.position.y + 1000;
        transform.position = new Vector3(dir, ypos, 0);
    }

    IEnumerator Attack()
    {
        if (isPause == false)
        {
            attack = true;
            float distance_x = transform.position.x - player.transform.position.x;
            float angle = Mathf.Atan2(distance_x, distance_y) * Mathf.Rad2Deg;
            print(angle);
            Enemy_AttackPattern.Instance.MultiShot(gameObject, bullet, 3, damage);
            yield return new WaitForSeconds(attackDelay);
            attack = false;
        }
    }

 
}
