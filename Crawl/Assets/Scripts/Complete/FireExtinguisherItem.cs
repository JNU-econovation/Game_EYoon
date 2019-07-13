using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireExtinguisherItem : Item
{
  
    public override void Function()
    {
        Inventory2.Instance.InsertItem(itemImage);
        player.GetComponent<Ability>().ChargeFireExCount();         
    }
    
   
}
