using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletItem : Item
{
    public GameObject player;
    public GameObject bullet;
    
    void Start()
    {        
    }

    new public void Function()
    {
        player.GetComponent<Attack>().NumberOfBullet += 5;
       
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {       
        if (collider.gameObject.tag == "Player")
        {
            Function();
            Destroy(gameObject);
            
        }
       
    }

}
