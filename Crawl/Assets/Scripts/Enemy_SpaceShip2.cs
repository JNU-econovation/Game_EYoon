using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_SpaceShip2 : Enemy
{
    GameObject player;
    [SerializeField] GameObject bullet;
    void Start()
    {
        player = LevelManager.Instance.GetPlayer();
        SetPosition();
        StartCoroutine(Attack());
    }

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
        transform.Translate(0, -speed, 0);
    }

    public override void SetPosition()
    {
        float dir = Random.Range(135, 576);
        float ypos = player.transform.position.y + 1000;
        transform.position = new Vector3(dir, ypos, 0);
    }
    IEnumerator Attack()
    {
        while (true)
        {
            yield return new WaitForSeconds(1.0f);
            Enemy_AttackPattern.Instance.SingleShot(gameObject, bullet, 0, damage);
        }
    }
}
