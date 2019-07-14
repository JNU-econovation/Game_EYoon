using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyDrinkItem : Item
{
    public override void Function()
    {
        player.GetComponent<Health>().IncreaseStamina(30);
    }
   
}
