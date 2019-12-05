using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class Enemy_UFO_bullet : MonoBehaviour
{
    public float speed = 5;
    protected float originSpeed;
    protected bool isPaused = false;
    protected int time;
    protected float lifeTime = 4.0f;
    protected int presentTime;
    // Update is called once per frame
    protected void Awake()
    {
        originSpeed = speed;
    }
    protected void OnEnable()
    {
        StartCoroutine(DestroySelf());
    }

    IEnumerator DestroySelf()
    {
        while (time < 10)
        {
            yield return new WaitForSeconds(lifeTime / 10);
            time += 1; ;
        }
        Destroy(gameObject);
    }
    abstract public void Stop();

    abstract public void Resume();
 
    
}
