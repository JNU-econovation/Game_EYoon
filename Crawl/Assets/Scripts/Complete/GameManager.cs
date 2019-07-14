using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int coin;
    GameObject player;
    bool GameOver = true;
    public GameObject coinItemPrefab;
    [SerializeField] GameObject GameOverUI;
    [SerializeField] GameObject ScoreUI;
    int delay = 3;
    private void Start()
    {
        player = GetComponent<LevelManager>().player;
    }

    void Update()
    {
   
        if(GameOver==true && player.GetComponent<Health>().hp == 0 ||
            GameOver == true && player.GetComponent<IsSearch>().isSearch == true)
        {
            StartCoroutine(Gameover());
        }
        coin = coinItemPrefab.GetComponent<CoinItem>().coin;
    }

    IEnumerator Gameover()
    {
        GameOver = false;
        player.GetComponent<PlayerMove>().forwardSpeed = 0;
        GameOverUI.SetActive(true);
        yield return new WaitForSeconds(delay);
        ScoreUI.SetActive(true);
    }
}
