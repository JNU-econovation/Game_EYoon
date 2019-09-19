using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class Item : MonoBehaviour
{   
    protected GameObject player;
    protected GameObject service;
    protected Sprite itemImage;
    public float lifeTime;
    private void Start()
    {
        itemImage = GetComponent<SpriteRenderer>().sprite;
    }
    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        service = GameObject.FindGameObjectWithTag("Service");
        
        
    }
    abstract public void Function();

    private void OnEnable()
    {
        StartCoroutine(DestroySelf());
    }

    public IEnumerator DestroySelf()
    {
        yield return new WaitForSeconds(lifeTime);
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
          //  Instantiate(service.GetComponent<Particles>().particles[Random.Range(0, service.GetComponent<Particles>().particles.Length-1)],collider.transform.position,collider.transform.rotation);
            Function();            
            Destroy(gameObject);
        }

    }
   
}
