using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealItem : Item
{
    public int increase;
    public override void Function()
    {
        player.GetComponent<Health>().hp += increase;
    }

   
}
