using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponLv3 : Item
{

    public override void Function()
    {
        level = 3;
        WeaponInventory.Instance.InsertItem(itemImage, level);
       
    }
   
}
