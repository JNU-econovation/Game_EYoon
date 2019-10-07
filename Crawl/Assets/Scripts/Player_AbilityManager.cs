using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_AbilityManager : Singleton<Player_AbilityManager>
{
    [SerializeField] [Range(0, 100)] float attack;
    [SerializeField] [Range(0, 100)] float defense;
    [SerializeField] [Range(0, 100)] float avoidance;
    [SerializeField] [Range(0, 100)] float critical_Percentage;
    [SerializeField] [Range(0, 100)] float critical_Hit;
    [SerializeField] [Range(0, 100)] float attackRange;
    [SerializeField] [Range(0, 100)] float attackSpeed;
    [SerializeField] [Range(0, 500)] float moveSpeed;
    [SerializeField] float HP;
    [SerializeField] float stamina;
    float maxHP = 100;
    float maxStamina = 100;
    
    
    //Get함수
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
        return attackRange;
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
    }
    public void SetAttackSpeed(float n)
    {
        attackSpeed = n;
    }
    public void SetAttackRange(float n)
    {
        attackRange = n;
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
    }
    public void IncreaseDefense(float n)
    {
        defense += n;
    }
    public void IncreaseAttack(float n)
    {
        attack += n;
    }
}
