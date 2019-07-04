using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class Item : MonoBehaviour
{   
    protected GameObject player;
    
    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    abstract public void Function();   
   
}
