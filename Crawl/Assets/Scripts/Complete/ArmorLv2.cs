using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmorLv2 : ArmorItem
{
    public override void Function()
    {
        level = 2;
        ArmorInventory.Instance.InsertItem(itemImage , level);        
    }
   
}
