using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ability : Singleton<Ability>
{
    public GameObject bullet;
    public float bulletDamage;
    public GameObject fireEx;
    public float damage;
    public float armor;
    public float maxArmor = 100;
    public float avoidance;
    public float hp;
    public int fireExCount;
    public float stamina;
    float maxStamina = 100;
    public float staminaDecreaseSpeed;
    public bool isRain;

    void Awake()
    {
        hp = GetComponent<Health>().hp;
        bulletDamage = bullet.GetComponent<Bullet>().damage;        
    }

    private void Update()
    {
        stamina -= Time.deltaTime * staminaDecreaseSpeed;
    }
    public void ChargeFireExCount()
    {
        fireExCount++;
    }

    public void IncreaseStamina(float increase)
    {
        stamina += increase;
        if(stamina >= maxStamina)
        {
            stamina = maxStamina;
        }
    }

    public void DecreaseStamina(float decrease)
    {
        stamina -= decrease;
        if(stamina < 1)
        {
            stamina = 0;
        }
    }
}
