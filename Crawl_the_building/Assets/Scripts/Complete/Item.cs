using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class Item : MonoBehaviour
{   
    protected GameObject player;
    public Sprite itemImage;

    private void Start()
    {
        itemImage = GetComponent<SpriteRenderer>().sprite;
    }
    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        
    }
    abstract public void Function();   
   
}
