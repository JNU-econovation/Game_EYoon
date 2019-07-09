using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponLv4 : Item
{
    public override void Function()
    {
        Inventory1.Instance.InsertItem(itemImage, 4);
        player.GetComponent<Ability>().damage = 40;
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            Function();
        }

    }
}
