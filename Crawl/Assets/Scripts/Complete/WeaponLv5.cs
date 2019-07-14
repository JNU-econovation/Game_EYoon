using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponLv5 : Item
{
  
    public override void Function()
    {
        WeaponInventory.Instance.InsertItem(itemImage, 5);
        player.GetComponent<Ability>().damage = 50;
        
    }
   
}
