using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JacketItem : Item
{
    static int itemLevel = 0;
    public GameObject snow;
    public override void Function()
    {
        if (itemLevel >= 5)
            return;
        itemLevel++;
        JacketInventory.Instance.InsertItem(itemImage, itemLevel);
        snow.GetComponent<Snow>().DecreaseDamage(itemLevel);
    }

    
    
}
