using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public GameObject playerPrefab;   
    public GameObject player;
   
    void Awake()
    {
        player = Instantiate(playerPrefab);   
        
    }

    
    void Update()
    {
        
    }
}
