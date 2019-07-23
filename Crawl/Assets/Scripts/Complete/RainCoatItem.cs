using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainCoatItem : Item
{
   
    public override void Function()
    {
        GameObject rainMaker = GameObject.FindGameObjectWithTag("Rain");
        rainMaker.GetComponent<RainMaker>().DownStaminaSpeed();               
    }   

    
}
