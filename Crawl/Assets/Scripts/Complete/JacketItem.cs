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
   
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            Function();
            gameObject.SetActive(false);
        }

    }

}
