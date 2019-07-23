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
    public void OnEnable(GameObject window, Sprite originWindow)
    {
        StartCoroutine(DestroySelf(window, originWindow));
    }

    public IEnumerator DestroySelf(GameObject window, Sprite originWindow)
    {
        yield return new WaitForSeconds(lifeTime);
        Destroy(gameObject);
        window.GetComponent<SpriteRenderer>().sprite = originWindow;
    }
    public abstract void Function(GameObject window);    
}
