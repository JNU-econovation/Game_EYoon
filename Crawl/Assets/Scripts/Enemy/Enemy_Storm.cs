using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Storm : Enemy
{
    GameObject player;
    float distance;
    // Start is called before the first frame update
    void Start()
    {
        player = LevelManager.Instance.GetPlayer();
        damage = GetComponent<Enemy_Ability>().GetDamage();
        SetPosition();
    }

    // Update is called once per frame
    void Update()
    {
        isPaused = EnemyManager.Instance.isPause;
        if (isPaused)
            speed = 0;
        else
        {
            time += Time.deltaTime;
            speed = originSpeed;
        }
        transform.Translate(0, -speed, 0);
        distance = player.transform.position.y - transform.position.y;
        if (distance > 650)
        {
            Destroy(gameObject);
        }
    }
 
    public override void SetPosition()
    {
        int dir = Random.Range(135, 576);
        float ypos = player.transform.position.y + 1000;
        transform.position = new Vector3(dir, ypos, 0);
    }

    
}
