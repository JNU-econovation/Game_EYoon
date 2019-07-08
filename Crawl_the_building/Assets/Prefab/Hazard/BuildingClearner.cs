using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingClearner : Hazard
{
    Vector3[] cleanerSpawnpos;
    Vector3 playerPos;
    [SerializeField] float speed = 2;
    [SerializeField] int damage = 50;

 
    private void Update()
    {
        transform.Translate(0, -speed,0);
    }
    // Start is called before the first frame update
    public override void Function(GameObject window)

    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.GetComponent<Health>().hp -= damage;
        }
    }
}
