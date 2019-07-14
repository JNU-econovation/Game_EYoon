using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmorLv4 : Item
{

    public override void Function()
    {
        ArmorInventory.Instance.InsertItem(itemImage , 4);
        player.GetComponent<Ability>().armor = 10;
    }
   
}
