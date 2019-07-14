using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponLv2 : Item
{
  
    public override void Function()
    {
        WeaponInventory.Instance.InsertItem(itemImage, 2);
        player.GetComponent<Ability>().damage = 20;
        
    }
  
}
