using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class block : MonoBehaviour
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
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.GetComponent<Health>().hp = other.GetComponent<Health>().hp - Damage;
            Destroy(gameObject);
        }

    }
}
