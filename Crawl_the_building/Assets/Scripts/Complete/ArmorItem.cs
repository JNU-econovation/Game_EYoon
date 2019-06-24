using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmorItem : Item
{
    public int increase;
   
    public override void Function()
    {       
            player.GetComponent<Ability>().armor += increase;            
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
