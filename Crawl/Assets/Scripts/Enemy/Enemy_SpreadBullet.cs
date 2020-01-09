using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_SpreadBullet : Enemy_UFO_bullet
{
    // Start is called before the first frame update
    [SerializeField] GameObject spreadBullet;
    [SerializeField] int count;
    float damage;
    float delay = 1.0f;
    int savedDelay;
    int num = 0;
    // Update is called once per frame
    private void Start()
    {
        originSpeed = speed;
        StartCoroutine(Spread());
    }
    void Update()
    {
        transform.Translate(0, -speed, 0);
        isPaused = EnemyManager.Instance.isPause;
        if (isPaused == true)
        {
            speed = 0;
        }
        else
        {
            time += Time.deltaTime;
            speed = originSpeed;
        }
    }

    IEnumerator Spread()
    {
        while (num < 10)
        {
            yield return new WaitForSeconds(delay/10);
            num += 1; ;
        }
        Enemy_AttackPattern.Instance.QuarterCircleShot(gameObject,spreadBullet,count, damage);
        Destroy(gameObject);
    }

}
