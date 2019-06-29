using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    public GameObject target;
    public int damage;
    Window window;
    
    void Update()
    {
        transform.Translate(Vector3.up * speed);
    }

    public void ReferenceTarget(GameObject obj){
        target = obj;
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        window = target.GetComponent<Window>();
        if (collider.gameObject == target)
        {            
            window.HP -= damage;           
            Destroy(gameObject);          
            window.ChangeWindow();
        }
    }
    
}
