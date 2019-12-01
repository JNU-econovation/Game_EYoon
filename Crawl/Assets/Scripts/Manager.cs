using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Manager : Singleton<Manager>
{
    public GameObject[] objects;
    public GameObject player;
    void Start()
    {
        
    }

    public void EndGame()
    {
        LevelManager.Instance.Pause();
        SceneManager.LoadScene("GameOver");
    }
}
