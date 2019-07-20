using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class WeaponItem : Item
{
    public float increase;
    public override void Function()
    {
        player.GetComponent<Ability>().IncreaseBulletDamage(increase);

    }
}
