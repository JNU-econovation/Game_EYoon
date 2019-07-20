using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JacketItem : Item
{
    public GameObject snow;
    static int jacketLevel = 0;
    void IncreaseLevel()
    {
        jacketLevel++;
    }
    public override void Function()
    {
        IncreaseLevel();
        snow.GetComponent<Snow>().DecreaseDamage(jacketLevel);
    }

    
    
}
