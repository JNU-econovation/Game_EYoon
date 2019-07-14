using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponLv4 : Item
{
    public override void Function()
    {
        Inventory1.Instance.InsertItem(itemImage, 4);
        player.GetComponent<Ability>().damage = 40;
        
    }

   
}
