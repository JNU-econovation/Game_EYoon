using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmorLv5 : ArmorItem
{

    public override void Function()
    {
        level = 5;
        ArmorInventory.Instance.InsertItem(itemImage, level);
    }
  
}
