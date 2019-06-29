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
    
    public void RecoverWindows(GameObject obj)
    {
        Window window= obj.GetComponent<Window>();   
        window.itemMade = false;
        window.HP = window.maxHP;       
        window.InitializeWindow();       
    }
    
}
