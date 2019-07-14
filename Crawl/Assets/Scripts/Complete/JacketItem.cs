using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JacketItem : Item
{
    public int increase;
    int itemLevel = 0;

    public override void Function()
    {
        itemLevel++;
        JacketInventory.Instance.InsertItem(itemImage, itemLevel);
    }
   
   

}
