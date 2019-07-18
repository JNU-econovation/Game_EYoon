using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainCoatItem : Item
{
    public GameObject rainMaker;
    public override void Function()
    {       
        RaincoatInventory.Instance.InsertItem(itemImage); 
        rainMaker.GetComponent<RainMaker>().SpeedDownStaminaSpeed();               
    }   

    
}
