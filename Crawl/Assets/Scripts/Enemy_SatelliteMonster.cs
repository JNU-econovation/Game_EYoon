using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_SatelliteMonster : Enemy
{
    GameObject player;
    Enemy_SatelliteBulletRotater Rotater;
    [SerializeField] float speed;
    float originSpeed;
    float damage;
    float distance;
    // Start is called before the first frame update
    void Start()
    {
        originSpeed = speed;
        Rotater = GetComponentInChildren<Enemy_SatelliteBulletRotater>();
        player = GameObject.FindGameObjectWithTag("Player");
        damage = GetComponent<Enemy_Ability>().GetDamage();
        SetPosition();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0,-speed,0);
        distance = player.transform.position.y - transform.position.y;
        if(distance > 650)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.tag == "Player")
        {
            Function();
        }
    }
    public override void Function()
    {
        Player_AbilityManager.Instance.DecreaseHP(damage);
        Destroy(gameObject);
    }
    public override void Pause()
    {
        speed = 0;
        if(Rotater != null)
        Rotater.Stop();
    }
    public override void Resume()
    {
        speed = originSpeed;
        Rotater.Resume();
    }




    public override void SetPosition()
    {
        int dir = Random.Range(135, 576);
        float ypos = player.transform.position.y + 1000;
        transform.position = new Vector3(dir,ypos,0);
    }

}
