using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinItem : Item
{
    public int increase;
    public int coin = 0;
    public override void Function()
    {
        coin += increase;
    }

    
}
