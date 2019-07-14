using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmorLv4 : Item
{

    public override void Function()
    {
        Inventory3.Instance.InsertItem(itemImage , 4);
        player.GetComponent<Ability>().armor = 10;
    }
   
}
