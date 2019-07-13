using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintWorker : Hazard
{
    public float speed;
    public int damage;
    public int hp;

    private void Start()
    {
        lifeTime = 8.0f;
    }
    private void Update()
    {
        transform.Translate(0, -speed, 0);
    }

    public override void Function(GameObject window)
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Bullet")
        {
            Destroy(collider.gameObject);
            hp -= collider.gameObject.GetComponent<Bullet>().damage;
            if (hp <= 0)
                Destroy(gameObject);
        }
        if (collider.gameObject.tag == "Player")
        {
            collider.gameObject.GetComponent<Health>().hp -= damage;
        }
    }
}
