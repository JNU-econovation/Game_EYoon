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
    public float maxArmor = 100.0f;
    public float avoidance;
    public int fireExCount;
  
    void Awake()
    {
        bulletDamage = bullet.GetComponent<Bullet>().damage;        
    }

    public void ChargeFireExCount()
    {
        fireExCount++;
    }
}
