using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField] float speed = 1;
    [SerializeField] int Damage;

    void Start()
    {
        Destroy(gameObject, 10f);
    }


    void Update()
    {
        transform.Translate(Vector3.up * speed);
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            collider.GetComponent<Health>().hp -= Damage;
            Destroy(gameObject);
        }
    }
}
