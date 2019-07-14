using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class Hazard : MonoBehaviour
{

    protected GameObject player;
    public float lifeTime;
   

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");

    }
    private void OnEnable()
    {
        StartCoroutine(DestroySelf());
    }

    public IEnumerator DestroySelf()
    {
        yield return new WaitForSeconds(lifeTime);
        Destroy(gameObject);
    }
    public abstract void Function(GameObject window);    
}
