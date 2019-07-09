using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponLv3 : Item
{
    
    public override void Function()
    {
        Inventory1.Instance.InsertItem(itemImage, 3);
        player.GetComponent<Ability>().damage = 30;
       
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
