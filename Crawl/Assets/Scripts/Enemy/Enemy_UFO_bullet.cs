using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class Enemy_UFO_bullet : MonoBehaviour
{
    public float speed = 5;
    protected float originSpeed;
    protected bool isPaused = false;
    // Update is called once per frame
    private void Awake()
    {
        originSpeed = speed;
    }
    void Update()
    {
        transform.Translate(0,-speed,0);
    }

    abstract public void Stop();

    abstract public void Resume();
 
    
}
