using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Invincibility : MonoBehaviour
{
    Player _player;
    float time = 0;
    bool isInvincible;
    float delayTime;
    float maxTime;
    [SerializeField] GameObject Invincibility;
    void Start()
    {
        _player = GetComponent<Player>();
    }
    
    void Update()
    {
        if (!_player.GetIsPause())
        {
            if (isInvincible)
            {
                time += Time.deltaTime;
                Invincibility.SetActive(true);
            }
            if (time >= maxTime)
            {
                isInvincible = false;
                Invincibility.SetActive(false);
            }
        }
    }

    public void OnInvincible(float temp)
    {
        isInvincible = true;
        time = 0;
        maxTime = temp;
    }
    public bool GetIsInvincible()
    {
        return isInvincible;
    }
}
