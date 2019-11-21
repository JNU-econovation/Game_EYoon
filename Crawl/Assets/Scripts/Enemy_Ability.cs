using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Ability : MonoBehaviour
{
    float HP;
    [SerializeField] float damage;
    float maxHP = 100;
    static float originMaxHP;
    static float originDamage;
    Enemy enemy;
    private void Start()
    {
        enemy = GetComponent<Enemy>();
        HP = maxHP;
        originMaxHP = maxHP;
        originDamage = damage;
    }
    public void Weak(float n)
    {
        maxHP = originMaxHP * (1 - n);
        damage = originDamage * (1 - n);
        if (HP >= maxHP)
            HP = maxHP;
        print(maxHP);
    }
    public float GetHp()
    {
        return HP;
    }
    public float GetDamage()
    {
        return damage;
    }
    public void DecreaseHP(float damage)
    {
        enemy.OnAttack = true;
        HP -= damage;
        if (HP <= 0)
        {
            HP = 0;
            Destroy(gameObject);
        }
    }
    public void IncreaseHP(float heal)
    {
        HP += heal;
        if (HP >= maxHP)
            HP = maxHP;
    }
    public void SetHP(float value)
    {
        HP = value;
        if (HP >= maxHP)
            HP = maxHP;
        else if(HP <= 0)
        {
            HP = 0;
            Destroy(gameObject);
        }
    }
}
