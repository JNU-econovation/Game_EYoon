using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Manager : Singleton<Manager>
{

    public GameObject[] objects;
    public GameObject player;
    static float height;

    public void ResetCount()
    {
        for(int i = 0; i < 5; i++)
        {
            ItemManager.Instance.items[i].GetComponent<Item>().ResetCount();
        }
    }
    public void EndGame()
    {
        ResetCount();
        height = UIManager.Instance.GetHeight();
        if (height > PlayerPrefs.GetInt("HighScore"))
        {
            PlayerPrefs.SetInt("HighScore", (int)height);
        }
        LevelManager.Instance.Pause();
        SceneManager.LoadScene("GameOver");
    }
    public int GetBestHeight()
    {
        return PlayerPrefs.GetInt("HighScore");
    }
    public float GetHeight()
    {
        return height;
    }

}
