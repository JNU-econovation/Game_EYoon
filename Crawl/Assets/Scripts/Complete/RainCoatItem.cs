using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainCoatItem : Item
{
    public float decrease;
    public override void Function()
    {
        player.GetComponent<Health>().DecreaseStaminaSpeed(decrease);         
    }   

    
}
