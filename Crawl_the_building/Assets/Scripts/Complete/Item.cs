using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class Item : MonoBehaviour
{
    protected GameObject item;
    protected GameObject player;
    
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    abstract public void Function();   
   
}
