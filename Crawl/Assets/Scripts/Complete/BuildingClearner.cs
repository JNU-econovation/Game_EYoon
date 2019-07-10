using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingClearner : Hazard
{
    Vector3[] cleanerSpawnpos;
    Vector3 playerPos;
    [SerializeField] float speed;
    [SerializeField] int damage;
    public int hp;
 
    private void Update()
    {
        transform.Translate(0, -speed,0);
    }
    
    public override void Function(GameObject window)
    {

    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            collider.gameObject.GetComponent<Health>().hp -= damage;
        }
        else if(collider.gameObject.tag == "Bullet")
        {
            Destroy(collider.gameObject);
            hp -= collider.gameObject.GetComponent<Bullet>().damage;
            if (hp <= 0)
                Destroy(gameObject);
        }
    }
}
