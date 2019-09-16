using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameManager : Singleton<GameManager>
{
    static public int coin;
    public Text coinText;
    GameObject player;
    bool GameOver = true;
    public GameObject coinItemPrefab;
    public GameObject gameOverUI;
    public GameObject scoreUI;
    int delay = 3;
    private void Start()
    {
        coin = 0;
        player = GetComponent<LevelManager>().player;
    }

    void Update()
    {
   
        if(GameOver==true && player.GetComponent<Health>().hp == 0 ||
            GameOver == true && player.GetComponent<IsSearch>().isSearch == true)
        {
            StartCoroutine(Gameover());
        }
        print(coin);
    }

    IEnumerator Gameover()
    {
        GameOver = false;
        gameOverUI.SetActive(true);
        yield return new WaitForSeconds(delay);
        scoreUI.SetActive(true);
    }

    public void IncreaseCoin(int n)
    {
        coin += n;
        coinText.text = coin.ToString();
    }
}
