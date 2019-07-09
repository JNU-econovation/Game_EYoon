using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    public float lifeTime = 5.0f;
    public float speed;
    public GameObject target;
    public int damage;
    public float hp;
    Window window;

    private void OnEnable()
    {
        StartCoroutine(DestroySelf());
    }

    public IEnumerator DestroySelf()
    {
        yield return new WaitForSeconds(lifeTime);
        Destroy(gameObject);
    }

    void Update()
    {
        transform.Translate(Vector3.up * speed);
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Bullet")       
            hp -= collider.gameObject.GetComponent<Bullet>().damage;        
       

       if(hp <= 0)
        {
            Destroy(gameObject);
            Destroy(collider.gameObject);
        }
          
        
    }
}
