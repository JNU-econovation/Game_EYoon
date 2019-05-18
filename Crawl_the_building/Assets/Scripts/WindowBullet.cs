using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowBullet : MonoBehaviour
{
    [SerializeField] float speed = 1;
    GameObject window;
    [SerializeField]GameObject bullet;
    [SerializeField] Sprite[] brokenWindow;
    private void Update()
    {
        transform.Translate(Vector3.up * speed);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if(collision.tag == "targetWindow" )
        {
            //collision.GetComponent<SpriteRenderer>().sortingOrder = 0;
            collision.GetComponent<SpriteRenderer>().sprite = brokenWindow[0];
            collision.tag = "Window";
            collision.GetComponent<Item>().NewBullet = bullet;
            collision.GetComponent<Item>().Break();
            Destroy(gameObject);
            
        }
    }
}
