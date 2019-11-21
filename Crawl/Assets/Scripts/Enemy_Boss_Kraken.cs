using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Boss_Kraken : MonoBehaviour
{
    [SerializeField] GameObject bullet;
    [SerializeField] GameObject monster;
    float damage;
    // Start is called before the first frame update
    void Start()
    {
        damage = GetComponent<Enemy_Ability>().GetDamage();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void BossAttackPattern1()
    {
        Enemy_AttackPattern.Instance.MultiShot(gameObject,bullet,9,damage);
    }
}
