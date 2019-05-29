using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeMap : MonoBehaviour
{
    Vector3 move;
    Vector3 spawn;
    public GameObject player;
    public GameObject newMap;
    GameObject temp;
    public float moveDistance;
 
    void Start()
    {
        move = new Vector3(0, moveDistance, 0);
        spawn = transform.position;
               
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject == player)
        {
            spawn += move;
            temp = Instantiate(newMap, spawn, Quaternion.identity);
            temp.name = temp.name.Replace("(Clone)", "");    
        }
    }
  
}
