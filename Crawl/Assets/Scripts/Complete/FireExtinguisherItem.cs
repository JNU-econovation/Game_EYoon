using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireExtinguisherItem : Item
{
    static int itemLevel = 0;

    public override void Function()
    {       
        FireExInventory.Instance.InsertItem(itemImage);
        player.GetComponent<Ability>().ChargeFireExCount();
        
    }
    
   
}
