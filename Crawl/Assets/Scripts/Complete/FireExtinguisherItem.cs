using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireExtinguisherItem : Item
{

    int itemLevel = 0;
    public override void Function()
    {
        itemLevel++;
        FireExInventory.Instance.InsertItem(itemImage, itemLevel);
        player.GetComponent<Ability>().ChargeFireExCount();         
    }
    
   
}
