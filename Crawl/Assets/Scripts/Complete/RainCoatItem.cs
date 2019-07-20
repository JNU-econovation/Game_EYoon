using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainCoatItem : Item
{
    public GameObject rainMaker;
   
    public override void Function()
    {

        rainMaker.GetComponent<RainMaker>().DownStaminaSpeed();               
    }   

    
}
