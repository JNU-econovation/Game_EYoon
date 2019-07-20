using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyDrinkItem : Item
{
    public int increase;
    public override void Function()
    {
        player.GetComponent<Health>().IncreaseStamina(increase);
    }
   
}
