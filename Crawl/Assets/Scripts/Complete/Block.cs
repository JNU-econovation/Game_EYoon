using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : Hazard
{
    public float speed;
    public int damage;
    public float hp;
    public GameObject hitEffect;
    public GameObject breakSound;
    public float[] itemWeight;
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
            ItemManager.Instance.MakeItem(gameObject.transform.position, itemWeight, 1);
        }
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        
        if(collider.gameObject.tag == "Player")
        {
            if (collider.gameObject.GetComponent<Ability>().IsAvoid())
            {
                AvoidText.Instance.MakeAvoidText();
                return;
            }
            collider.gameObject.GetComponent<Health>().DecreaseHP(damage);
            collider.GetComponent<AudioSource>().enabled = false;
            collider.GetComponent<AudioSource>().enabled = true;
            Destroy(gameObject);
        }
        
    }

    public override void Function(GameObject window)
    {
        
    }
}
