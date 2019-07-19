using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmorLv1 : ArmorItem
{
    public override void Function()
    {
        level = 1;
        ArmorInventory.Instance.InsertItem(itemImage, level);
    }
   
}
