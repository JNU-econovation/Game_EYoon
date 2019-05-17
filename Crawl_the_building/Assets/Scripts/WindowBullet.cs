using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowBullet : MonoBehaviour
{
    [SerializeField] float speed = 1;
    GameObject window;
    int rand;
    private void Update()
    {
        transform.Translate(Vector3.up * speed);
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {

        if(collider.tag == "targetWindow")
        {
            collider.GetComponent<SpriteRenderer>().sortingOrder = 0;
            collider.tag = "Window";
           // window = collision.GetComponent;
            Destroy(gameObject);
            rand = Random.Range(0, 2);
            if (rand == 1)
                collider.GetComponent<Item>().Bullet();
            else
                collider.GetComponent<Item>().Heal();
        }
    }
}
