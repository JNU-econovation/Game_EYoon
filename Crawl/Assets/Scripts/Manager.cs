using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Manager : Singleton<Manager>
{
    Player _player;
    public GameObject[] objects;
    public GameObject player;
    static float height;
    private void Start()
    {
        player = LevelManager.Instance.GetPlayer();
        _player = player.GetComponent<Player>();
    }
    public void ResetCount()
    {
        for(int i = 0; i < 5; i++)
        {
            ItemManager.Instance.items[i].GetComponent<Item>().ResetCount();
        }
        _player.InitializeValue();
        SkillManager.Instance.InitializeValue();
        Bomb.Instance.SetDamage(10);
    }
    public void EndGame()
    {
        ResetCount();
        height = UIManager.Instance.GetHeight();
        PlayerPrefs.SetInt("Height", (int)height);
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
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

}
