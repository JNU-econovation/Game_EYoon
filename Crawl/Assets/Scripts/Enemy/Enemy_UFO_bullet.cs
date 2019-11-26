using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_UFO_bullet : MonoBehaviour
{
    
    float speed = 5;
    float originSpeed;
    // Update is called once per frame
    private void Start()
    {
        originSpeed = speed;        
    }
    void Update()
    {
        transform.Translate(0,-speed,0);
    }

    public void Stop()
    {
        speed = 0;
    }

    public void Resume()
    {
        speed = originSpeed;
    }
    
}
