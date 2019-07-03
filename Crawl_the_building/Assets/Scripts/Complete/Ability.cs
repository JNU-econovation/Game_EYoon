using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ability : MonoBehaviour
{
    public GameObject bullet;
    public GameObject fireEx;
    public float damage;
    public float armor;
    public float maxArmor = 100;
    public float avoidance;
    public float hp;
    public int fireExCount;
    
    void Awake()
    {
        hp = GetComponent<Health>().hp;
        damage = bullet.GetComponent<Bullet>().damage;
        fireExCount = fireEx.GetComponent<FireExtinguisherItem>().FireExCount; ;
    }

    
}
