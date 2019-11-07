using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_UFO : Enemy
{
    public int birdPos;
    int direction;
    float damage;
    [SerializeField] int speed;
    [SerializeField] GameObject bullet;
    [SerializeField] float attackRange;
    [SerializeField] float attackDelay;
    int originSpeed;
    bool attack = false;
    GameObject player;
    // Start is called before the first frame update
    private void Start()
    {
        player = LevelManager.Instance.GetPlayer();
        //player = GameObject.FindGameObjectWithTag("Player");
        SetPosition();
        originSpeed = speed;
        damage = GetComponent<Enemy_Ability>().GetDamage();
        //player = LevelManager.Instance.getPlayer();
        // 아직 getPlayer에서 현재 게임 플래이 중인 플래이어를 불러올수 없어 오류가생겨요
    }
    private void Update()
    {
        float distance_y = transform.position.y - player.transform.position.y;

        transform.Translate(5 * direction, 0, 0);
        if(attack == false && distance_y < attackRange)
        {
            StartCoroutine(Attack(distance_y));
        }

        if(transform.position.x < -110 || transform.position.x > 811)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Player")
        {
            Function();
        }
    }
    public override void Function()
    {
        Player_AbilityManager.Instance.DecreaseHP(damage);
        Destroy(gameObject);
    }

    IEnumerator Attack(float distance_y)
    {
        attack = true;
        float distance_x = transform.position.x - player.transform.position.x;
        float angle = Mathf.Atan2(distance_x, distance_y) * Mathf.Rad2Deg;
        print(angle);
        Enemy_AttackPattern.Instance.SingleShot(gameObject, bullet, -angle, damage);
        yield return new WaitForSeconds(attackDelay);
        attack = false;
    }


    public override void SetPosition()
    {
        int dir = Random.Range(0, 100);
        int birdPos = 700 + Random.Range(0, 200);
        float playerHeight = player.transform.position.y;
        if (dir <= 50)
        {
            GetComponent<SpriteRenderer>().flipX = true;
            transform.position = new Vector2(796, birdPos + playerHeight);
            direction = -1;
        }
        else if (50 < dir && dir <= 100)
        {
            transform.position = new Vector2(-76, birdPos + playerHeight);
            direction = 1;
        }
    }

}
