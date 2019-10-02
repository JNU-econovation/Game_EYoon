using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map_Controler : MonoBehaviour
{
    public GameObject map;
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.tag == "Player")
        {
            map.transform.Translate(0, 3600, 0);
        }
    }
}
