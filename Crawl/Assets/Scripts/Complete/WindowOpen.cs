using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowOpen : Hazard
{
    public override void Function(GameObject window)
    {
        GameObject temp = ItemManager.Instance.MakeItem(transform.position);
        Destroy(temp, 5.0f);
    }
   
}
