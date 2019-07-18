using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JacketItem : Item
{
    public GameObject snow;
    public override void Function()
    {      
        JacketInventory.Instance.InsertItem(itemImage);
        snow.GetComponent<Snow>().DecreaseDamage();
    }

    
    
}
