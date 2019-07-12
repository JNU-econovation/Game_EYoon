using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    public GameObject target;
    public int damage;
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

    public void ReferenceTarget(GameObject obj){
        target = obj;
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {

        if (collider.gameObject == target && collider.gameObject.tag == "Window")
        {
            Window window = collider.gameObject.GetComponent<Window>();
            window.HP -= damage;           
            Destroy(gameObject);            
            window.ChangeWindow();
        }
    }
    
}
