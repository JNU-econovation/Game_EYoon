using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainCoatItem : Item
{
    static float increase = 0.1f;
    public override void Function()
    {
        player.GetComponent<Health>().UmbrellaCount(increase);         
    }   

    
}
