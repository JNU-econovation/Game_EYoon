using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_DetectPlayer : MonoBehaviour
{
    float dist;
    Player_Circle_Move player_Circle_Move;
    Player_Attack player_Attack;
    float radius;
    GameObject player;
    bool isInclude;
    private void Start()
    {
        player = LevelManager.Instance.GetPlayer();
        player_Circle_Move = player.GetComponentInChildren<Player_Circle_Move>();
        player_Attack = player.GetComponent<Player_Attack>();
        StartCoroutine(DetectPlayer());
    }

    IEnumerator DetectPlayer()
    {
        while (true)
        {
            yield return null;           
            if (!isInclude)
            {
                if (dist <= radius)
                {
                    player_Attack.targetList.Add(gameObject);
                    isInclude = true;
                }
            }
            else
            {
                if (dist > radius)
                {
                    player_Attack.targetList.Remove(gameObject);
                    isInclude = false;
                }
            }
        }
    }
    void Update()
    {
        radius = player_Circle_Move.getRadius();
        dist = Vector2.Distance(transform.position, player.transform.position);        
    }
    private void OnDisable()
    {
        player_Attack.targetList.Remove(gameObject);
    }
}
