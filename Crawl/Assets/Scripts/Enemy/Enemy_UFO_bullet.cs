using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class Enemy_UFO_bullet : MonoBehaviour
{
    public float speed = 5;
    protected float originSpeed;
    protected bool isPaused = false;
    protected float time;
    protected float lifeTime = 4.0f;
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
        while (true)
        {
            yield return null;
            if (time >= lifeTime)
            {            
                Destroy(gameObject);
            }
        }

    }

}
