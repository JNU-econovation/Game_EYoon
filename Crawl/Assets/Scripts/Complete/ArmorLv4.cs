using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmorLv4 : Item
{
    public override void Function()
    {
        level = 4;
        ArmorInventory.Instance.InsertItem(itemImage , level);
    }
   
}
