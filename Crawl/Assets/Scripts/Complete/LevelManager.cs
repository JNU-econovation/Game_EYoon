using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public GameObject playerPrefab;   
    public GameObject player;
    public GameObject rainMaker;
    public GameObject rainPrefab;
    public GameObject[] map;

    void Awake()
    {
        player = Instantiate(playerPrefab);       
        rainMaker = Instantiate(rainPrefab);
        rainMaker.SetActive(false);
        for (int i = 0; i < map.Length; i++)
            player.GetComponent<PlayerMove>().map[i] = map[i];
    }
    
    public void RecoverWindows(GameObject obj)
    {
        Window window= obj.GetComponent<Window>();   
        window.itemMade = false;
        window.HP = window.maxHP;       
        window.InitializeWindow();       
    }
    
}
