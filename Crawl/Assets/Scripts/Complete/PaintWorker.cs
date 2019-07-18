using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PaintWorker : Hazard
{
    public Image hpImage;
    public float speed;
    public float damage;
    public float hp;
    public float maxHp;
    public float[] itemWeight;

    private void Update()
    {
        transform.Translate(0, -speed, 0);
    }

    public override void Function(GameObject window)
    {
        
    }
  
    void DecreaseHP(float n)
    {
        hp -= n;
        if (hp <= 0)
        {
            Destroy(gameObject);            
            ItemManager.Instance.MakeItem(gameObject.transform.position, itemWeight);
        }           
        hpImage.fillAmount = hp / maxHp;
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Bullet")
        {
            float bulletDamage = player.GetComponent<Ability>().bulletDamage;
            DecreaseHP(bulletDamage);          
        }
        if (collider.gameObject.tag == "Player")
        {
            if (collider.gameObject.GetComponent<Ability>().IsAvoid())
            {
                AvoidText.Instance.MakeAvoidText();
                return;
            }
            collider.gameObject.GetComponent<Health>().DecreaseHP(damage);
        }
    }
}
