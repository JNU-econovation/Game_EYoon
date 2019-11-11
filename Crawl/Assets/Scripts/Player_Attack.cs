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
                    enemy_colliders[i].GetComponent<SpriteRenderer>().color = new Color(255, 0, 0, 255);
                    enemy_colliders[i].GetComponent<Enemy_Ability>().DecreaseHP(realDamage);
                    Player_AbilityManager.Instance.Drain(realDamage);
                }              
            }
            
            yield return new WaitForSeconds(1.0f / attackSpeed);
        }       
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
