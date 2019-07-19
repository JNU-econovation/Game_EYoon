using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponLv4 : WeaponItem
{

    public override void Function()
    {
        level = 4;
        WeaponInventory.Instance.InsertItem(itemImage, level);
        
    }

   
}
