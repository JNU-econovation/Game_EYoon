using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Invincibility : MonoBehaviour
{
    float time = 0;
    bool isInvincible;
    float delayTime;
    float maxTime;
    void Start()
    {
        StartCoroutine(Invincible());
    }

    IEnumerator Invincible()
    {
        while (true)
        {
            yield return null;
            if (isInvincible)
            {
                if (time >= maxTime)
                {
                    isInvincible = false;
                }

            }
        }
    }
    
    void Update()
    {
        if (isInvincible)
            time += Time.deltaTime;
        else
            time = 0;
    }

    public void OnInvincible(float time)
    {
        isInvincible = true;
        maxTime = time;
    }
    public bool GetIsInvincible()
    {
        return isInvincible;
    }
}
