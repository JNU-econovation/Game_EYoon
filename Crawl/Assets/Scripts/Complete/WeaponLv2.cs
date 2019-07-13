using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponLv2 : Item
{
  
    public override void Function()
    {
        Inventory1.Instance.InsertItem(itemImage, 2);
        player.GetComponent<Ability>().damage = 20;
        
    }
  
}
