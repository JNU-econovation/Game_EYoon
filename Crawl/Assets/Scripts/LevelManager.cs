using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public GameObject playerPrefab;
    GameObject player;
    void Awake()
    {
      //player = Instantiate(playerPrefab);
    }

    public GameObject getPlayer()
    {
        return player;
    }
}
