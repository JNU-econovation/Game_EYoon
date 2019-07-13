using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainCoatItem : Item
{
    public float increase;
    
    public override void Function()
    {
        Inventory2.Instance.InsertItem(itemImage);        
        player.GetComponent<PlayerMove>().forwardSpeed += increase;          
    }   

    
}
