using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmorLv3 : Item
{
    public override void Function()
    {
        Inventory3.Instance.InsertItem(itemImage, 3);
        player.GetComponent<Ability>().armor = 10;
    }
    
}
