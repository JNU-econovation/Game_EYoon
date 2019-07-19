using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class Item : MonoBehaviour
{
    public int level;
    protected GameObject player;
    protected Sprite itemImage;
    public float lifeTime;
    private void Start()
    {
        itemImage = GetComponent<SpriteRenderer>().sprite;
    }
    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        
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
            Function();            
            Destroy(gameObject);
        }

    }
   
}
