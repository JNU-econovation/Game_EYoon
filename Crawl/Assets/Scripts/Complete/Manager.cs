using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Manager : Singleton<Manager>
{
    static public int coin;
    public Text coinText;
    GameObject player;
    bool GameOver = true;
    public GameObject gameOverUI;
    public GameObject scoreUI;
    public GameObject GameCompleteUI;
    int delay = 3;
    public float height;
    private void Start()
    {
        coin = 0;
        player = GetComponent<LevelManager>().player;
    }
    public void GameComplete()
    {
        GameCompleteUI.SetActive(true);
        StartCoroutine(Complete());
    }
    public void Gameover()
    {
        GameOver = false;
        StopPlayer();
        gameOverUI.SetActive(true);
        StartCoroutine(Delay(delay));
    }

    public void StopPlayer()
    {
        player.GetComponent<PlayerMove>().forwardSpeed = 0;
    }

    IEnumerator Delay(float delay)
    {
        yield return new WaitForSeconds(delay);
        scoreUI.SetActive(true);
    }
    IEnumerator Complete()
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene("PrefapForge");
    }
    public void IncreaseCoin(int n)
    {
        coin += n;
        coinText.text = coin.ToString();
    }
}
