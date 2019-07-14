using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BulletItem : Item
{
    public int increase;
    public override void Function()
    {

       
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {       
        if (collider.gameObject.tag == "Player")
        {
            Function();
            gameObject.SetActive(false);
        }        
    }   
}
