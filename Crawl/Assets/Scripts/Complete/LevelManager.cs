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
    public List<GameObject> hazards;
    public GameObject disturbance;
    public List<GameObject> items;
    void Awake()
    {
        player = Instantiate(playerPrefab);
       
        for(int i = 0; i < disturbance.GetComponent<HazardManager>().hazards.Count; i++)
        {
            GameObject temp = Instantiate(disturbance.GetComponent<HazardManager>().hazards[i]);
            hazards.Add(temp);
            temp.SetActive(false);
        }        
        for(int i = 0; i < GetComponent<ItemManager>().item.Count; i++)
        {
            GameObject temp = Instantiate(GetComponent<ItemManager>().item[i]);
            items.Add(temp);
            temp.SetActive(false);
        }
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
