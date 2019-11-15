using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Booster : MonoBehaviour
{
    bool onBooster;
    Player_Move player_Move;
    float time = 0;
    void Start()
    {
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
                break;
            }
        }
    }
    private void Update()
    {
        time += Time.deltaTime;
        if (onBooster)
        {
            transform.Translate(0, 1000 * Time.deltaTime, 0);
        }
    }
}
