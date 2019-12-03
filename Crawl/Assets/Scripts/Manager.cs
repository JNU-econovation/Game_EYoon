using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Manager : Singleton<Manager>
{

    public GameObject[] objects;
    public GameObject player;
    static float height;
    static float bestHeight;
    public void EndGame()
    {
        height = UIManager.Instance.GetHeight();
        if(height > bestHeight)
        {
            bestHeight = height;
        }
        LevelManager.Instance.Pause();
        SceneManager.LoadScene("GameOver");
    }
    public float GetBestHeight()
    {
        return bestHeight;
    }
    public float GetHeight()
    {
        return height;
    }
}
