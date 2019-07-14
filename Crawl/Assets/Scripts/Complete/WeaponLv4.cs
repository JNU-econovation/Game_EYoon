using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponLv4 : Item
{
    public override void Function()
    {
        WeaponInventory.Instance.InsertItem(itemImage, 4);
        player.GetComponent<Ability>().damage = 40;
        
    }

   
}
