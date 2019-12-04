using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Booster : MonoBehaviour
{
    bool onBooster;
    bool OnBoss;
    [SerializeField] GameObject booster;
    Player_Move player_Move;
    Player _player;
    float time = 0;
    void Start()
    {
        _player = GetComponent<Player>();
        player_Move = GetComponent<Player_Move>();
    }

    public void Booster(float delayTime)
    {
        time = 0;
        onBooster = true;
        StartCoroutine(Delay(delayTime));
        
    }
    public bool GetOnBooster()
    {
        return onBooster;
    }
    IEnumerator Delay(float delayTime)
    {

        while (true)
        {
            yield return null;
            if(time >= delayTime)
            {
                onBooster = false;                
            }
            if (!onBooster)
                break;
        }
    }
    private void Update()
    {
        OnBoss = LevelManager.Instance.OnBoss;
        if (!_player.GetIsPause())
        {
            if (onBooster && !OnBoss)
            {
                time += Time.deltaTime;
                transform.Translate(0, 1000 * Time.deltaTime, 0);
                booster.SetActive(true);
            }
            else
                booster.SetActive(false);
            if (OnBoss)
                onBooster = false;
        }
       
    }
}
