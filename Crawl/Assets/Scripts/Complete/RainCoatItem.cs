using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainCoatItem : Item
{
    public GameObject rainMaker;
    int itemLevel = 0;
    public override void Function()
    {
        itemLevel++;
        RaincoatInventory.Instance.InsertItem(itemImage, itemLevel); 
        rainMaker.GetComponent<RainMaker>().SpeedDownStaminaSpeed();               
    }   

    
}
