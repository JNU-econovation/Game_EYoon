using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class Enemy_Boss : MonoBehaviour
{
    public float stopPos = 371;
    protected GameObject player;
    public float hp =1000;
    protected float maxHp;
    public float speed = 3.0f;
    protected float originSpeed;
    public float speed_x = 1.5f;
    protected float originSpeed_x;
    public float damage;
    public GameObject[] bullets;
    public GameObject[] monsters;
    protected bool isPaused = false;
    protected float distance_y;
    protected bool attack = false;
    public float attackDelay =2.0f;
    public bool onAttack = false;
    private void Awake()
    {
        originSpeed = speed;
        originSpeed_x = speed_x;
    }
    public void DecreaseHP(float damage)
    {
        onAttack = true;
        hp -= damage;
        if (hp <= 0)
        {
            hp = 0;
            Destroy(gameObject);
        }
    }
    abstract public void SetPosition();

}
