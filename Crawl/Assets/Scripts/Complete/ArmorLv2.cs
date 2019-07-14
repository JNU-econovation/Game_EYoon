using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmorLv2 : Item
{
    public override void Function()
    {
        level = 2;
        ArmorInventory.Instance.InsertItem(itemImage , level);        
    }
   
}
