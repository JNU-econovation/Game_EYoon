using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public GameObject p;   
    public GameObject player;
   
    void Awake()
    {
        player = Instantiate(p);       
    }

    
    void Update()
    {
        
    }
}
