using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponLv1 : WeaponItem
{
 
    public override void Function()
    {
        level = 1;
        WeaponInventory.Instance.InsertItem(itemImage, level);               
    }
   
}
