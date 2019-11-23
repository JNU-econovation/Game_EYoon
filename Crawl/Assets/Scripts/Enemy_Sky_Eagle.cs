using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Sky_Eagle : Enemy
{
    GameObject player;
    Animator animator;
    bool isAttack;
    bool isMade;
    float time = 0;
    public GameObject tornadoBullet;
    void Start()
    {
        animator = GetComponent<Animator>();
        player = LevelManager.Instance.GetPlayer();
        SetPosition();
        StartCoroutine(Attack());
    }

    IEnumerator Attack()
    {
        while (true)
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
                    animator.SetBool("IsAttack", true);
                    Instantiate(tornadoBullet, transform.position, new Quaternion(1,0,0.3f,0));
                    isAttack = true;
                }
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (isPaused)
            speed = 0;
        else if (isPaused == false)
            speed = originSpeed;
        transform.Translate(speed, -speed, 0);
       
    }
    public override void Pause()
    {
    }

    public override void Resume()
    {
    }

    public override void SetPosition()
    {
        float dir = Random.Range(135, 576);
        float ypos = player.transform.position.y + 1000;
        transform.position = new Vector3(-100, ypos, 0);

    }
}
