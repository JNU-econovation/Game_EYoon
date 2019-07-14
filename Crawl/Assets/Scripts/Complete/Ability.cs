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
    float[] avoidWeight = new float[2];
    void Awake()
    {
        bulletDamage = bullet.GetComponent<Bullet>().damage;        
    }

    public void ChargeFireExCount()
    {
        fireExCount++;
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
