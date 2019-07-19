using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponLv5 : WeaponItem
{

    public override void Function()
    {
        level = 5;
        WeaponInventory.Instance.InsertItem(itemImage, level);       
    }
   
}
