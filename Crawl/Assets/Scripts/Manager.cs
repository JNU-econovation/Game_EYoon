using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : Singleton<Manager>
{
    public GameObject[] objects;
    public GameObject player;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void EndGame()
    {
        for(int i = 0; i < objects.Length; i++)
        {
            objects[i].SetActive(false);
        }
        LevelManager.Instance.Pause();
        UIManager.Instance.gameover_UI.SetActive(true);
    }
}
