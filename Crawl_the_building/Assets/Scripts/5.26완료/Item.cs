using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    protected GameObject item;
    public GameObject player;
    public void Function()
    {

    }
    private void OnTriggerEnter2D(Collider2D collider)
    {     
    }
    public virtual void MakeItem(Vector3 vector3)
    {
        print("item");
    }



}
