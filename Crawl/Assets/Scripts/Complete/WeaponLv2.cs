using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponLv2 : Item
{


    public override void Function()
    {
        level = 2;
        WeaponInventory.Instance.InsertItem(itemImage, level);
        
    }
  
}
