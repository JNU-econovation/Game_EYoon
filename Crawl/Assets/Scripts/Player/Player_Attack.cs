using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Player_Attack : MonoBehaviour
{
    float attackSpeed;
    int targetNum;
    float attack_range; // 실제 반지름 = range * 45
    public LayerMask layerMask;
    bool[] isAttack = new bool[4];   
    bool isFire;
    bool isFreeze;
    float attackTime;
    float fireTime;
    float time1;
    float time2;
    float freezeTime;
    Player_Circle_Move circle_Move;
    Player _player;
    public List<GameObject> targetList = new List<GameObject>();
    private void Start()
    {
        _player = GetComponent<Player>();
        circle_Move = GetComponentInChildren<Player_Circle_Move>();
        StartCoroutine(DetectAttack());
    }
    private void Update()
    {
        if (!_player.GetIsPause())
        {
            attackTime += Time.deltaTime;
            if (isFreeze)
            {
                time1 += Time.deltaTime;
                if (time1 >= freezeTime)
                {
                    isFreeze = false;
                }
            }
            if (isFire)
            {
                time2 += Time.deltaTime;
                if(time2 >= fireTime)
                {
                    isFire = false;
                }
            }
        }
        attack_range = Player_AbilityManager.Instance.GetAttackRange();
        
    }

    IEnumerator DetectAttack()
    {
        while (true)
        {
            targetNum = Player_AbilityManager.Instance.GetTargetNum();
            int n = 0;
            if(targetNum <= targetList.Count)
            {
                n = targetNum;                
            }
            else
            {
                n = targetList.Count;
            }
            if (!isAttack[0])
                StartCoroutine(Attack_First_Enemy(n));
            yield return null;
        }
    }
    IEnumerator Attack_First_Enemy(int n)
    {
        try
        {
            isAttack[0] = true;
            for (int i = 0; i < n; i++)
            {
                float damage = RealAttack();
                if (i >= targetList.Count)
                    break;
                targetList[i].GetComponent<Enemy>().ShowDamage(damage, new Color(255, 255, 255,255));
                targetList[i].GetComponent<Enemy_Ability>().DecreaseHP(damage);
                
                Player_AbilityManager.Instance.Drain(damage);
                if (isFire)
                {
                    StartCoroutine(Fire(targetList[i]));
                }
                if (isFreeze)
                {
                    StartCoroutine(Freeze(targetList[i]));
                }

            }
        }
        catch (ArgumentOutOfRangeException e) { }
        if (targetList.Count == 0)
        {
            isAttack[0] = false;
            yield return null;
        }
        else
        {
            attackSpeed = Player_AbilityManager.Instance.GetAttackSpeed();
            yield return new WaitForSeconds(1 / attackSpeed);
            isAttack[0] = false;
        }
        
       
    }
    
    IEnumerator Fire(GameObject enemy)
    {
        GameObject fire = EffectManager.Instance.Fire(enemy.transform);
        while (true)
        {
            if (isFire)
            {
                if (enemy != null)
                {
                    float hp = enemy.GetComponent<Enemy_Ability>().GetHp();
                    float damage = hp * 0.2f;
                    enemy.GetComponent<Enemy_Ability>().DecreaseHP(damage);
                    Player_AbilityManager.Instance.Drain(damage);
                    enemy.GetComponent<Enemy>().ShowDamage(damage, new Color(255,0,0));
                }
                yield return new WaitForSeconds(1.0f);
            }
            else
                break;
            yield return null;
        }
        Destroy(fire);
      
    }
    IEnumerator Freeze(GameObject enemy)
    {
       GameObject freeze = EffectManager.Instance.Freeze(enemy.transform);
        enemy.GetComponent<SpriteRenderer>().color = new Color(0, 255, 255, 140);
        while (true)
        {
            yield return null;
            if (enemy != null)
            {
                enemy.GetComponent<Enemy>().Pause();
                if(!isFreeze)
                {
                    if (enemy != null)
                    {
                        enemy.GetComponent<Enemy>().Resume();
                        break;
                    }                   
                }
            }
        }
        Destroy(freeze);
        enemy.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 255);
            
    }
    public void OnFreeze(float n)
    {
        time1 = 0;
        freezeTime = n;
        isFreeze = true;
    }
    public void OnFire(float n)
    {
        time2 = 0;
        fireTime = n;
        isFire = true;
    }
    
    public float RealAttack()
    {
        float damage = Player_AbilityManager.Instance.GetAttack();
        float critical_Percentage = Player_AbilityManager.Instance.GetCritical_Percentage();
        float critical_Hit = Player_AbilityManager.Instance.GetCritical_HIt();
        bool isCritical = Player_AbilityManager.Instance.GetIsCritical();
        float realDamage;
        float rand = UnityEngine.Random.Range(0, 100);
        if (rand < critical_Percentage || isCritical)
        {
            realDamage = damage * (critical_Hit / 100);
        }
        else
        {
            realDamage = damage;
        }

        return realDamage;
    }
}
