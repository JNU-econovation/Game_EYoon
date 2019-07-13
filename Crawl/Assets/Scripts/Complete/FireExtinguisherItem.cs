using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireExtinguisherItem : Item
{
    public int FireExCount = 0;
  
    public override void Function()
    {
        Inventory2.Instance.InsertItem(itemImage);
        FireExCount = 3;         
    }
    
   
}
