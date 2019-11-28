using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_UI : Singleton<Enemy_UI>
{
    public GameObject enemy_Damage;
    public Transform hudPos;
    public void TakeDamage(GameObject enemy,float damage)
    {
        GameObject hudText = Instantiate(enemy_Damage);
        hudText.transform.position = enemy.transform.position + new Vector3(100,100,0);
        hudText.GetComponent<Enemy_DamageText>().damage = damage;
    }
}
