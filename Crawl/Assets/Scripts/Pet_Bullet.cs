using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pet_Bullet : MonoBehaviour
{
    float damage;
    float critical_hit;
    float critical_Percent;
    float speed = 10;
    float time = 0;
    private void Update()
    {
        transform.Translate(0, speed, 0);
        critical_hit = Player_AbilityManager.Instance.GetCritical_HIt();
        critical_Percent = Player_AbilityManager.Instance.GetCritical_Percentage();
        damage = Player_AbilityManager.Instance.GetAttack();
        if (!LevelManager.Instance.isPause)
        {
            time += Time.deltaTime;
            if(time >= 10.0f)
            {
                Destroy(gameObject);
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.tag == "Enemy")
        {
            float rand = Random.Range(0.01f, 100);
            if (rand <= critical_Percent)
                damage = damage * critical_hit / 100;
            collider.GetComponent<Enemy>().ShowDamage(damage, new Color(255, 255, 255), 0);
            collider.GetComponent<Enemy_Ability>().DecreaseHP(damage);
            Destroy(gameObject);
        }
    }
}
