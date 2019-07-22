using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Lighning : MonoBehaviour
{
    float lifeTime = 3.0f;
   [SerializeField] GameObject player;
    public int delay = 1;
   [SerializeField] GameObject warning;
   [SerializeField]
    public float damege;
    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    private void OnEnable()
    {        
        StartCoroutine(DestroySelf());
    }

    IEnumerator DestroySelf()
    {
        yield return new WaitForSeconds(lifeTime);
        gameObject.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            collider.gameObject.GetComponent<Health>().DecreaseHP(damege);
        }
    }
}
