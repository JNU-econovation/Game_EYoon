using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Effect : MonoBehaviour
{
    GameObject player;
    Player_Attack player_Attack;
    public GameObject fire;
    public GameObject freeze;
    private void Start()
    {
        player = LevelManager.Instance.GetPlayer();
        player_Attack = player.GetComponent<Player_Attack>();
    }

    private void Update()
    {
        if (player_Attack.isFire)
        {
            fire = EffectManager.Instance.fire_effect;
            fire.SetActive(true);
            fire.transform.position = transform.position;
        }
        else
        {
            fire.SetActive(false);
        }

        if (player_Attack.isFreeze)
        {
            freeze = EffectManager.Instance.freeze_effect;
            freeze.SetActive(true);
            freeze.transform.position = transform.position;
        }
        else
        {
            if (freeze != null)
            {
                freeze.SetActive(false);
            }
        }
    }
}
