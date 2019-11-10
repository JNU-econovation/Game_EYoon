using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_AbilityManager : Singleton<Player_AbilityManager>
{
    float realAttack;
    [SerializeField] [Range(0, 100)] float attack;
    [SerializeField] [Range(0, 100)] float defense;
    [SerializeField] [Range(0, 100)] float avoidance;
    [SerializeField] [Range(0, 100)] float critical_Percentage;
    [SerializeField] [Range(100, 1000)] float critical_Hit;
    [SerializeField] [Range(0, 100)] float attackRange;
    [SerializeField] float attackSpeed = 1;
    [SerializeField] [Range(0, 1000)] float moveSpeed;
    [SerializeField] [Range(0, 5)] int targetNum;
    float reflectDamage = 0;
    float drain;
    float maxDrain = 30;
    int maxTargetNum = 5;
    float maxAttackSpeed = 5;
    float maxAvoidance = 80.0f;
    [SerializeField] float HP;
    [SerializeField] float stamina;
    float maxHP = 1000;
    float maxStamina = 1000;
    Player_Attack_Range player_Attack_Range;
    bool isCritical = false;
    private void Start()
    {
        player_Attack_Range = GetComponentInChildren<Player_Attack_Range>();
    }

    private void Update()
    {
        moveSpeed += Time.deltaTime;
    }
    public void Critical(float time)
    {
        StartCoroutine(CriticalHit(time));
    }
    IEnumerator CriticalHit(float time)
    {
        isCritical = true;
        yield return new WaitForSeconds(time);
        isCritical = false;
    }
    public float Attack()
    {
        float rand = Random.Range(0, 100);
        if(rand <= critical_Percentage || isCritical)
        {
            realAttack = attack * (critical_Hit / 100);
        }
        else
        {
            realAttack = attack;
        }
        return realAttack;
    }
    public void Drain(float realAttack)
    {
        HP += realAttack * (drain / 100);
        if (HP > maxHP)
            HP = maxHP;
    }
    //Get함수
    public bool GetIsCritical()
    {
        return isCritical;
    }
    public float GetMaxHP()
    {
        return maxHP;
    }
    public float GetMaxStamina()
    {
        return maxStamina;
    }
    public float GetHP()
    {
        return HP;
    }
    public float GetStamina()
    {
        return stamina;
    }
    public float GetMoveSpeed()
    {
        return moveSpeed;
    }
    public float GetAttackSpeed()
    {
        return attackSpeed;
    }
    public float GetAttackRange()
    {
        return player_Attack_Range.GetAttackRange();
    }
    public float GetCritical_HIt()
    {
        return critical_Hit;
    }
    public float GetCritical_Percentage()
    {
        return critical_Percentage;
    }
    public float GetAvoidance()
    {
        return avoidance;
    }
    public float GetDefense()
    {
        return defense;
    }
    public float GetAttack()
    {
        return attack;
    }
    public int GetTargetNum()
    {
        return targetNum;
    }
    public float GetDrain()
    {
        return drain;
    }
    public float GetReflectDamage()
    {
        return reflectDamage;
    }
    //Set함수
    public void IncreaseMaxHP(float n)
    {
        HP += n;
        maxHP += n;
    }
    public void IncreaseHP(float n)
    {
        HP += n;
        if (HP >= maxHP)
            HP = maxHP;      
    }
    public void SetHP(float n)
    {
        HP = n;
        if (HP >= maxHP)
            HP = maxHP;
        else if (HP < 0)
            HP = 0;
    }
    public void SetStamina(float n)
    {
        stamina = n;
        if (stamina >= maxStamina)
            stamina = maxStamina;
        else if (stamina < 0)
            stamina = 0;
    }

    public void DecreaseHP(float n)
    {
        HP -= (n - defense);
        if (HP < 0)
            HP = 0;
    }
    public void IncreaseMaxStamina(float n)
    {
        stamina += n;
        maxStamina += n;
    }
    public void IncreaseStamina(float n)
    {
        stamina += n;
        if (stamina >= maxStamina)
            stamina = maxStamina;
    }
    public void DecreseStamina(float n)
    {
        stamina -= n;
        if (stamina < 0)
            stamina = 0;
    }
    public void DecreaseMoveSpeed(float n)
    {
        moveSpeed -= n;
        if (moveSpeed <= 300.0f)
            moveSpeed = 300.0f;
    }
    public void IncreaseAttackSpeed(float n)
    {
        attackSpeed += n;
        if (attackSpeed > maxAttackSpeed)
            attackSpeed = maxAttackSpeed;
    }
    public void IncreaseAttackRange(float n)
    {
        player_Attack_Range.IncreaseAttackRange(n);
    }
    public void IncreaseCritical_HIt(float n)
    {
        critical_Hit += n;
    }
    public void IncreaseCritical_Percentage(float n)
    {
        critical_Percentage += n;
    }
    public void increaseAvoidance(float n)
    {
        avoidance += n;
        if (avoidance >= maxAvoidance)
            avoidance = maxAvoidance;
    }
    public void IncreaseDefense(float n)
    {
        defense += n;
    }
    public void IncreaseAttack(float n)
    {
        attack += n;
    }
    public void IncreaseTargetNum()
    {
        targetNum++;
        if (targetNum > maxTargetNum)
            targetNum = maxTargetNum;
    }
    public void IncreaseDrain(float n)
    {
        drain += n;
        if (drain > maxDrain)
            drain = maxDrain;
    }
    public void IncreaseReflectDamage(float n)
    {
        reflectDamage += n;
        if (reflectDamage >= 100)
            reflectDamage = 100.0f;
    }
}
