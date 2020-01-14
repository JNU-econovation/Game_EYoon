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
    bool skill_end_invince;
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
                if(!skill_end_invince)
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
    public void SetIsInvincible(bool t)
    {
        isInvincible = t;
    }
    public void Skill_end_Invince(float temp)
    {
        isInvincible = true;
        skill_end_invince = true;
        time = 0;
        maxTime = temp;
    }
}
