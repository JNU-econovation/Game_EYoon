using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Manager : Singleton<Manager>
{
    GameObject inGameSound;
    GameObject gameCompleteSound;
    GameObject gameOverSound;
    GameObject gameOverUI;
    GameObject scoreUI;
    GameObject player;
    static public int coin = 0;
    public Text coinText;
    bool gameOver = true;
    float delayTime = 3.0f;
    public GameObject hpBar;

    private void Start()
    {
        player = GetComponent<LevelManager>().player;

        gameOverUI = GetComponent<UIManager>().gameOverUI;
        scoreUI = GetComponent<UIManager>().scoreUI;

        inGameSound = GetComponent<SoundManager>().inGameSound;
        gameCompleteSound = GetComponent<SoundManager>().gameCompleteSound;
        gameOverSound = GetComponent<SoundManager>().gameOverSound;
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
  
    public void IncreaseCoin(int n)
    {
        coin += n;
        coinText.text = coin.ToString();
    }
}
