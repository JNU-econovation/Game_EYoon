using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : Hazard
{
    public float speed;
    public int damage;
    public float hp;
    public GameObject hitEffect;
    Window window;

    void Update()
    {
        transform.Translate(Vector3.up * speed);
    }

    void DecreaseHP(float damage)
    {
        hp -= damage;
        if (hp <= 0)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Bullet")
        {
            GameObject effect = Instantiate(hitEffect);
            effect.transform.position = collider.gameObject.transform.position;

            Destroy(collider.gameObject); // 총알 제거
            float bulletDamage = player.GetComponent<Ability>().bulletDamage;
            DecreaseHP(bulletDamage);
        }
        if(collider.gameObject.tag == "Player")
        {
            if (collider.gameObject.GetComponent<Ability>().IsAvoid())
            {
                AvoidText.Instance.MakeAvoidText();
                return;
            }
            collider.gameObject.GetComponent<Health>().DecreaseHP(damage);           
            Destroy(gameObject);
        }
        
    }

    public override void Function(GameObject window)
    {
        
    }
}
