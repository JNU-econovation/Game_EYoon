using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Boss_Phynics : Enemy
{
    public float stopPos = 371;
    protected GameObject player;
    public GameObject[] bullets;
    public GameObject[] monsters;
    protected float distance_y;
    protected bool attack = false;
    public float attackDelay = 2.0f;
    public bool onAttack = false;
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
        if (transform.position.y < 39900)
        {
            speed = 0;
            if (attack == false)
            {

                Attack();
            }
            if (transform.position.x < 85 || transform.position.x > 635)
            {
                speed_x = speed_x * -1;
                originSpeed_x = speed_x;
                if (GetComponent<SpriteRenderer>().flipX == true)
                    GetComponent<SpriteRenderer>().flipX = false;
                else
                    GetComponent<SpriteRenderer>().flipX = true;
            }
            transform.Translate(speed_x, 0, 0);

        }
        transform.Translate(0, -speed, 0);
    }
    void Attack()
    {
        int rand = Random.Range(0, 4);
        print(rand);
        switch (rand)
        {
            case 0:
                StartCoroutine(SpreadBullet());
                break;
            case 1:
                StartCoroutine(FireSpreadBullet());
                break;
            case 2:
                StartCoroutine(FireSatelliteBullet());
                break;
            case 3:
                StartCoroutine(SpawnMonster());
                break;


        }
    }
    IEnumerator SpreadBullet()
    {
        attack = true;
        Enemy_AttackPattern.Instance.MultiShot(gameObject, bullets[0], Random.Range(3, 7), damage);
        yield return new WaitForSeconds(attackDelay);
        attack = false;
    }
    IEnumerator FireSpreadBullet()
    {
        attack = true;
        Enemy_AttackPattern.Instance.MultiShot(gameObject, bullets[1], Random.Range(1, 5), damage);
        yield return new WaitForSeconds(attackDelay);
        attack = false;
    }

    IEnumerator FireSatelliteBullet()
    {
        attack = true;
        float distance_x = transform.position.x - player.transform.position.x;
        float distance_y = transform.position.y - player.transform.position.y;
        float angle = Mathf.Atan2(distance_x, distance_y) * Mathf.Rad2Deg;
        Enemy_AttackPattern.Instance.SingleShot(gameObject, bullets[2], angle, damage);
        yield return new WaitForSeconds(attackDelay);
        attack = false;
    }
    IEnumerator SpawnMonster()
    {
        attack = true;
        int rand = Random.Range(0, monsters.Length - 1);
        GameObject monster = Instantiate(monsters[rand]);
        yield return new WaitForSeconds(attackDelay);
        attack = false;
    }

    public override void SetPosition()
    {

        float ypos = player.transform.position.y + 1000;
        transform.position = new Vector3(360, 40900, 0);
    }

    public override void Resume()
    {
        throw new System.NotImplementedException();
    }

    public override void Pause()
    {
        throw new System.NotImplementedException();
    }
    private void OnDisable()
    {
        LevelManager.Instance.bossClear = true;
        Item_Explosion.Instance.Explosion(transform.position);
    }
    public override void SetAbillity(float color_R, float color_G, float color_B, float hp, float damage, float bulletCount)
    {
        throw new System.NotImplementedException();
    }
}
