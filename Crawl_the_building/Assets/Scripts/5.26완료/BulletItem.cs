using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BulletItem : Item
{
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
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
    new public void MakeItem(Vector3 vector3)
    {
        print("bulletitem");
        item = GameObject.Find("BulletItem");
       
        transform.position = vector3;
        Instantiate(item);
        
    }


}
