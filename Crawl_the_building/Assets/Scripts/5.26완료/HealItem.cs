using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealItem : Item
{
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    new public void Function()
    {
        player.GetComponent<Health>().hp += 10;

    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            Function();
            Destroy(gameObject);
        }

    }
    new public void MakeItem(Vector3 vector3)
    {
        print("healitem");
        item = GameObject.Find("HealItem");
        transform.position = vector3;
        Instantiate(item);
    }
}
