using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ability : Singleton<Ability>
{
    public GameObject bullet;
    public float bulletDamage;
    float maxBulletDamage = 100;
    public float damage;
    public float armor;
    public float maxArmor = 80.0f;
    public float avoidance;
    public bool isReverse = false;
    static int jacketLevel;
    GameObject snow;
    float[] avoidWeight = new float[2];

    void Awake()
    {
        bulletDamage = bullet.GetComponent<Bullet>().damage;        
    }


    public int TakeJacketLevel()
    {
        jacketLevel++;
        return jacketLevel;
    }
    public void IncreaseArmor(float n)
    {
        armor += n;
        if(armor >= 80.0f)
        {
            armor = 80.0f;
        }
    }

    public void IncreaseBulletDamage(float n)
    {
        bulletDamage += n;
        if(bulletDamage >= maxBulletDamage)
        {
            bulletDamage = maxBulletDamage;
        }
        bullet.GetComponent<Bullet>().damage = bulletDamage;
    }

    int SelectAvoid()
    {
        avoidWeight[0] = avoidance;
        avoidWeight[1] = 100 - avoidance;
        float rand = Random.Range(0, 100);
        float total = 0;
        for (int i = 0; i < avoidWeight.Length; i++)
        {
            total += avoidWeight[i];
            if (rand <= total)
                return i;
        }
        return avoidWeight.Length - 1;
    }
    public bool IsAvoid()
    {
        return SelectAvoid() == 0;
    }

  

}
