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
    public void OnEnable()
    {
        StartCoroutine(DestroySelf());
    }

    public IEnumerator DestroySelf()
    {
        yield return new WaitForSeconds(lifeTime);
        /*
        for (int i = 1; i < 11; i++)
        {
            gameObject.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 1 - i * 0.1f);
            yield return new WaitForSeconds(lifeTime/10);
        }*/
        Destroy(gameObject);
        HazardManager.Instance.CloseWindow();
    }
    void CloseWindow(GameObject window, Sprite originWIndow)
    {
        window.GetComponent<SpriteRenderer>().sprite = originWIndow;
    }
    public abstract void Function(GameObject window);    
}
