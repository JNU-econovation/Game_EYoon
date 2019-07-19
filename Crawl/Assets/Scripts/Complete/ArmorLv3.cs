using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmorLv3 : ArmorItem
{
    public override void Function()
    {
        level = 3;
        ArmorInventory.Instance.InsertItem(itemImage, level);
    }
    
}
