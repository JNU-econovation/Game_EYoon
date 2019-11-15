using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_SpreadBullet : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject spreadBullet;
    [SerializeField] int count;
    float damage;
    float speed = 5;
    float originSpeed;
    float delay = 1.0f;
    // Update is called once per frame
    private void Start()
    {
        originSpeed = speed;
    }
    void Update()
    {
        transform.Translate(0, -speed, 0);
    }

    IEnumerator Spread()
    {
        yield return new WaitForSeconds(delay);
        Enemy_AttackPattern.Instance.CircleShot(gameObject,spreadBullet,count, damage);
    }
}
