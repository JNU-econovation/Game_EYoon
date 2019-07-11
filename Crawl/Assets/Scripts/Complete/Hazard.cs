using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class Hazard : MonoBehaviour
{

    protected GameObject player;
    public float lifeTime = 5.0f;
   

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");

    }
     
    public abstract void Function(GameObject window);    
}
