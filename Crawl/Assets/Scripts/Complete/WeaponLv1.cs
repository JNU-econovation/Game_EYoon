using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponLv1 : Item
{
    
    public override void Function()
    {
        Inventory1.Instance.InsertItem(itemImage, 1);
        player.GetComponent<Ability>().damage = 10;
        
    }
   
}
