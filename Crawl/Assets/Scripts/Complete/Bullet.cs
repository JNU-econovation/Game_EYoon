using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    public GameObject target;
    public float damage;
    public float lifeTime;
   
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

        if (collider.gameObject == target && collider.gameObject.tag == "Window")
        {
            Window window = collider.gameObject.GetComponent<Window>();
            window.GetComponent<Window>().DecreaseHP(damage);           
            Destroy(gameObject);            
            window.ChangeWindow();
        }
    }
    
}
