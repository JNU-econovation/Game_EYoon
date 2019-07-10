using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowOpen : Hazard
{
    public override void Function(GameObject window)
    {
        ItemManager.Instance.MakeItem(transform.position);        
    }
    
}
