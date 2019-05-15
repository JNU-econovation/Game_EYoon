using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowBullet : MonoBehaviour
{
    [SerializeField] float speed = 1;
    private void Update()
    {
        transform.Translate(Vector3.up * speed);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "targetWindow")
        {
            collision.GetComponent<SpriteRenderer>().sortingOrder = 0;
            collision.tag = "Window";
            Destroy(gameObject);
        }
    }
}
