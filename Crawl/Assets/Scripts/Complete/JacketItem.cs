using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JacketItem : Item
{
    public int increase;


    public override void Function()
    {
        Inventory2.Instance.InsertItem(itemImage);
    }
   
   

}
