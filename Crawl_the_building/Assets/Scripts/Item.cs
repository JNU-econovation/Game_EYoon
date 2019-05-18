using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public GameObject NewBullet;
    public int hitCount = 0;
   
   
    void Start()
    {
        
    }
    public void Break()
    {
        NewBullet.transform.position = transform.position;
        Instantiate(NewBullet);
        Debug.Log(11);
    }
    
   
}
