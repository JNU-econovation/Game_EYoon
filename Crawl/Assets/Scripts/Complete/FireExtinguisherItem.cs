using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireExtinguisherItem : Item
{
    static int fireExCount = 0;
    public int GetFireExCount()
    {
        return fireExCount;
    }
    void ChargeFireExCount()
    {
        fireExCount++;
    }
    public void DisChargeFireExCount()
    {
        fireExCount--;
        if(fireExCount <= 0)
        {
            fireExCount = 0;
        }
    }
    public override void Function()
    {
        ChargeFireExCount();
        FireExInventory.Instance.ChangeCount(fireExCount);
    }   
   
}

