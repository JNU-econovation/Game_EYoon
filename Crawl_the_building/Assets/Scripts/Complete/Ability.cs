using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ability : MonoBehaviour
{
    public GameObject bullet;
    public GameObject fireEx;
    public float damage;
    public float armor;
    public float avoidance;
    public int fireExCount;
    
    void Start()
    {
        damage = bullet.GetComponent<Bullet>().damage;
        fireExCount = fireEx.GetComponent<FireExtinguisherItem>().FireExCount; ;
    }

    void Update()
    {
        
    }
}
