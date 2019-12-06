using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Manager : Singleton<Manager>
{

    public GameObject[] objects;
    public GameObject player;
    static float height;
    static int bestHeight;
    private void Start()
    {
        PlayerPrefs.GetInt("HighScore", bestHeight);
    }
    public void ResetCount()
    {
        ItemManager.Instance.item_Copper.ResetCount();
        ItemManager.Instance.item_Silver.ResetCount();
        ItemManager.Instance.item_Gold.ResetCount();
        ItemManager.Instance.item_Diamond.ResetCount();
        ItemManager.Instance.item_Ruby.ResetCount();
    }
    public void EndGame()
    {
        ResetCount();
        height = UIManager.Instance.GetHeight();
        if(height > bestHeight)
        {
            bestHeight = (int)height;
        }
        PlayerPrefs.SetInt("HighScore", bestHeight);
        LevelManager.Instance.Pause();
        SceneManager.LoadScene("GameOver");
    }
    public int GetBestHeight()
    {
        return bestHeight;
    }
    public float GetHeight()
    {
        return height;
    }

}
