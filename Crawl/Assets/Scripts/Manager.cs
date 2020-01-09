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
        for(int i = 0; i < 5; i++)
        {
            ItemManager.Instance.items[i].GetComponent<Item>().ResetCount();
        }
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
