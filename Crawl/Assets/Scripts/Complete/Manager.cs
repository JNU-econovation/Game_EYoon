using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Manager : Singleton<Manager>
{
    public GameObject inGameSound;
    public GameObject gameCompleteSound;
    static public int coin;
    public Text coinText;
    GameObject player;
    bool gameOver = true;
    public GameObject gameOverUI;
    public GameObject scoreUI;
    public GameObject GameCompleteUI;
    float delayTime = 3.0f;
    public GameObject heightUI;
    public GameObject hpBar;
    public GameObject gameOverSound;
    private void Start()
    {
        coin = 0;
        player = GetComponent<LevelManager>().player;
    }
   
    public void GameComplete()
    {
        inGameSound.GetComponent<AudioSource>().Stop();
        Instantiate(gameCompleteSound);
        player.GetComponent<PlayerMove>().forwardSpeed = 0;
        GameCompleteUI.SetActive(true);
       // StartCoroutine(LoadEndingScene());
    }
    public void Gameover()
    {
        inGameSound.GetComponent<AudioSource>().Stop();
        Instantiate(gameOverSound);
        StopPlayer();
        hpBar.SetActive(false);
        gameOverUI.SetActive(true);
        StartCoroutine(Delay(delayTime));
        gameOver = false;
    }

    public void StopPlayer()
    {
        player.GetComponent<PlayerMove>().forwardSpeed = 0;
        player.GetComponent<Rigidbody2D>().gravityScale = 1;       
    }

    IEnumerator Delay(float delayTime)
    {        
        yield return new WaitForSeconds(delayTime);
        scoreUI.SetActive(true);
        Time.timeScale = 0;

    }
    IEnumerator LoadEndingScene()
    {
        yield return new WaitForSeconds(delayTime);
        SceneManager.LoadScene("PrefapForge");
    }
    public void IncreaseCoin(int n)
    {
        coin += n;
        coinText.text = coin.ToString();
    }
}
