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
    Enemy_Ability enemy_Ability;
    Enemy enemy;
    bool isFire;
    bool isFreeze;
    GameObject fire;
    GameObject freeze;
    float time = 0;
    private void Start()
    {
        enemy = GetComponent<Enemy>();
        enemy_Ability = GetComponent<Enemy_Ability>();
           player = LevelManager.Instance.GetPlayer();
        player_Circle_Move = player.GetComponentInChildren<Player_Circle_Move>();
        player_Attack = player.GetComponent<Player_Attack>();
        StartCoroutine(DetectPlayer());
        fire = EffectManager.Instance.fire_effect;
        freeze = EffectManager.Instance.freeze_effect;
        fire = Instantiate(fire, transform.position, Quaternion.identity);
        freeze = Instantiate(freeze, transform.position, Quaternion.identity);
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
                float distY = player.transform.position.y - transform.position.y;
                /*if(distY > 0)
                {
                    player_Attack.targetList.Remove(gameObject);
                    break;
                }*/
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
        
        if (player_Attack.isFire)
        {
            time += Time.deltaTime;
            if(time >= 1.0f)
            {
                enemy_Ability.DecreaseHP(enemy_Ability.GetHp() * 0.2f);
                enemy.GetComponent<Enemy>().ShowDamage(enemy_Ability.GetHp() * 0.2f, new Color(255, 0, 0), 1);
                time = 0;
            }
            fire.SetActive(true);
            fire.transform.position = transform.position;
        }
        else 
        {
            fire.SetActive(false);
        }

        if (player_Attack.isFreeze)
        {
            freeze.SetActive(true);
            freeze.transform.position = transform.position;
        }
        else
        {
            freeze.SetActive(false);
        }
    }
    private void OnDisable()
    {
        if(fire != null)
            fire.SetActive(false);
        if(freeze != null)
            freeze.SetActive(false);
        player_Attack.targetList.Remove(gameObject);
    }
}
