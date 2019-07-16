using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainCoatItem : Item
{
    public GameObject rainMaker;
    static int itemLevel = 0;
    public override void Function()
    {
        if (itemLevel >= 5)
            return;
        itemLevel++;        
        RaincoatInventory.Instance.InsertItem(itemImage, itemLevel); 
        rainMaker.GetComponent<RainMaker>().SpeedDownStaminaSpeed();               
    }   

    
}
