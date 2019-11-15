using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Attack : MonoBehaviour
{
    float attackSpeed;
    int targetNum;
    float attack_range; // 실제 반지름 = range * 70
    public Collider2D[] enemy_colliders;
    public LayerMask layerMask;
    bool isAttack = false;
    bool isFire;
    bool isFreeze;
    int fireTime;
    float freezeTime;
    private void Start()
    {     
        StartCoroutine(DetectAttack());
    }
    private void Update()
    {
        attack_range = Player_AbilityManager.Instance.GetAttackRange();
        enemy_colliders = Physics2D.OverlapCircleAll(transform.position, attack_range * 70.0f, layerMask, 0, 20);
    }
    IEnumerator DetectAttack()
    {
        while (true)
        {
            attackSpeed = Player_AbilityManager.Instance.GetAttackSpeed();
            targetNum = Player_AbilityManager.Instance.GetTargetNum();            
            if(enemy_colliders.Length > 0 && !isAttack)
            {
                isAttack = true;
                StartCoroutine(Attack());
            }
            yield return null;
        }
    }
    IEnumerator Attack()
    {
        while (true)
        {
            if (enemy_colliders.Length == 0)
            {
                isAttack = false;
                break;
            }
            for (int i = 0; i < targetNum; i++)
            {
                if (enemy_colliders[i] != null)
                {
                    float realDamage = RealAttack();
                    GameObject temp = enemy_colliders[i].gameObject;
                    temp.GetComponent<SpriteRenderer>().color = new Color(255, 0, 0, 255);
                    temp.GetComponent<Enemy_Ability>().DecreaseHP(realDamage);
                    Player_AbilityManager.Instance.Drain(realDamage);
                    if (isFire)
                        StartCoroutine(Fire(fireTime, temp));
                    if (isFreeze)
                        StartCoroutine(Freeze(freezeTime, temp));
                }              
            }
            
            yield return new WaitForSeconds(1.0f / attackSpeed);
        }       
    }
    IEnumerator Fire(int n, GameObject enemy)
    {
        for(int i = 0;i < n; i++)
        {
            if(enemy != null)
            {
                float hp = enemy.GetComponent<Enemy_Ability>().GetHp();
                enemy.GetComponent<Enemy_Ability>().DecreaseHP(hp * 0.2f);
                Player_AbilityManager.Instance.Drain(hp * 0.2f);
            }            
            yield return new WaitForSeconds(1.0f);
        }
        isFire = false;
    }
    IEnumerator Freeze(float n, GameObject enemy)
    {
        if(enemy != null)
        {
            enemy.GetComponent<Enemy>().Pause();
            yield return new WaitForSeconds(n);
            if(enemy != null)
            {
                enemy.GetComponent<Enemy>().Resume();
            }          
            isFreeze = false;
        }       
    }
    public void OnFreeze(float n)
    {
        freezeTime = n;
        isFreeze = true;
    }
    public void OnFire(int n)
    {
        fireTime = n;
        isFire = true;
    }
    
    public Collider2D[] GetEnemyTarget()
    {
        return enemy_colliders;
    }
    public float RealAttack()
    {
        float damage = Player_AbilityManager.Instance.GetAttack();
        float critical_Percentage = Player_AbilityManager.Instance.GetCritical_Percentage();
        float critical_Hit = Player_AbilityManager.Instance.GetCritical_HIt();
        bool isCritical = Player_AbilityManager.Instance.GetIsCritical();
        float realDamage;
        float rand = Random.Range(0, 100);
        if (rand <= critical_Percentage || isCritical)
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
