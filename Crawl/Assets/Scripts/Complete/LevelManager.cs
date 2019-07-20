using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : Singleton<LevelManager>
{
    public GameObject playerPrefab;   
    public GameObject player;
    public GameObject[] map;
    public float height;
    public float maxHeight;
    public List<GameObject> fireList = new List<GameObject>();

    private void Start()
    {
        maxHeight *= 10;
    }

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

    private void Update()
    {
        height = player.transform.position.y / 10;
        if(height >= maxHeight)
        {
            GetComponent<Manager>().GameComplete();
        }
    }

}
