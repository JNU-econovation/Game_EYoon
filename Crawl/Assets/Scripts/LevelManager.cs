using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : Singleton<LevelManager>
{
    public GameObject playerPrefab;
    GameObject player;
    void Awake()
    {
        player = playerPrefab;       
        //player = Instantiate(playerPrefab);
    }
   
    public GameObject GetPlayer()
    {
        return player;
    }

}
