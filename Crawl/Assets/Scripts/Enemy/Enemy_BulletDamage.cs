using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_BulletDamage : MonoBehaviour
{
    float damage;
    public float lifeTime = 5;
    private void Start()
    {
        Destroy(gameObject, lifeTime);
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            Player_AbilityManager.Instance.DecreaseHP(damage);
            Destroy(gameObject);
        }
    }

    public void Setdamage(float dam)
    {
        damage = dam;
    }
}
