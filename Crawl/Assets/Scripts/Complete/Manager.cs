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
<<<<<<< HEAD
    float delay = 3;
=======
    public GameObject GameCompleteUI;
    int delay = 3;
    public float height;
>>>>>>> 9898543bf34c0e72a66c95aa70065e579e043a07
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
<<<<<<< HEAD
=======
    }

    public void StopPlayer()
    {
        player.GetComponent<PlayerMove>().forwardSpeed = 0;
>>>>>>> 9898543bf34c0e72a66c95aa70065e579e043a07
    }

    IEnumerator Delay(float delay)
    {        
        yield return new WaitForSeconds(delay);
        scoreUI.SetActive(true);
<<<<<<< HEAD
        Time.timeScale = 0;
=======
    }
    IEnumerator Complete()
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene("PrefapForge");
>>>>>>> 9898543bf34c0e72a66c95aa70065e579e043a07
    }
    public void IncreaseCoin(int n)
    {
        coin += n;
        coinText.text = coin.ToString();
    }
}
