using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeMap : MonoBehaviour
{
    Vector3 spawn;
    public GameObject newMap;
    GameObject temp;
    public float moveDistance;
 
    void Start()
    {
        spawn  = transform.position + new Vector3(0, moveDistance, 0);              
    }
    
    private void OnTriggerEnter2D(Collider2D collider)
    {
       
        if(collider.gameObject.tag == "Player")
        {            
            temp = Instantiate(newMap, spawn, Quaternion.identity);
            temp.name = temp.name.Replace("(Clone)", "");    
        }
              
    }

}
