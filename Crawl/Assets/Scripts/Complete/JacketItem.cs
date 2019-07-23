using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JacketItem : Item
{  

    public override void Function()
    {
        player.GetComponent<Ability>().TakeJacketLevel();
    }

    
    
}
