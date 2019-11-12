using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Ability : MonoBehaviour
{
    [SerializeField] float HP;
    [SerializeField] float damage;
    float maxHP = 100;
    // Start is called before the first frame update
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
