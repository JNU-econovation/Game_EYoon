using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponLv3 : Item
{
    
    public override void Function()
    {
        WeaponInventory.Instance.InsertItem(itemImage, 3);
        player.GetComponent<Ability>().damage = 30;
       
    }
   
}
