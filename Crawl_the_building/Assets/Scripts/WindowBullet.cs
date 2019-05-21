using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowBullet : MonoBehaviour
{
    [SerializeField] float speed = 1;
    GameObject window;

    [SerializeField]GameObject bullet;
    [SerializeField] Sprite[] brokenWindow; // 부서진 창문 이미지 등록 0부터 HP적은순

    int rand;
    int HP;

    private void Update()
    {
        transform.Translate(Vector3.up * speed);
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
      HP = collider.GetComponent<Item>().Hp;
        if(collider.tag == "targetWindow" && HP == 1 )
        {
            collider.GetComponent<Item>().Hp = HP - 1;
            collider.GetComponent<SpriteRenderer>().sprite = brokenWindow[0];

            collider.tag = "Window";
            Destroy(gameObject);
            rand = Random.Range(0, 2);
            if (rand == 1)
                collider.GetComponent<Item>().Bullet();
            else
                collider.GetComponent<Item>().Heal();
        }
        else if (collider.tag == "targetWindow" && HP == 2)
        {
            collider.GetComponent<SpriteRenderer>().sprite = brokenWindow[1];
            collider.GetComponent<Item>().Hp = HP - 1;
            collider.tag = "Window";
            Destroy(gameObject);
            Debug.Log(collider.GetComponent<Item>().Hp);
        }
        else if (collider.tag == "targetWindow" && HP == 3)
        {
            collider.GetComponent<SpriteRenderer>().sprite = brokenWindow[2];
            collider.GetComponent<Item>().Hp = HP - 1;
            collider.tag = "Window";
            Destroy(gameObject);
            Debug.Log(collider.GetComponent<Item>().Hp);
        }
        else if (collider.tag == "targetWindow" && HP == 4)
        {
            collider.GetComponent<SpriteRenderer>().sprite = brokenWindow[3];
            collider.GetComponent<Item>().Hp = HP - 1;
            collider.tag = "Window";
            Destroy(gameObject);
            Debug.Log(collider.GetComponent<Item>().Hp);
        }


    }

   
}
