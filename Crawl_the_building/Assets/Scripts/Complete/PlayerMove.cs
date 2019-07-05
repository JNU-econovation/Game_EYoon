using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float forwardSpeed;
    float xPos;
    float blanketYpos;
    private void Awake()
    {

    }

    void Update()
    {
        xPos = Mathf.Clamp(transform.position.x, 330.0f, 390.0f);
        transform.position = new Vector3(xPos, transform.position.y, transform.position.z);
        transform.Translate(0, forwardSpeed, 0); // 앞으로 이동 
        
    }
}
