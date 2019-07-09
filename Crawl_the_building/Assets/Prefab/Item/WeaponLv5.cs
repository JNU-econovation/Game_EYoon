using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponLv5 : Item
{
    public override void Function()
    {
        player.GetComponent<Ability>().damage = 50;
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            Function();
            Destroy(gameObject);
        }

    }
}
