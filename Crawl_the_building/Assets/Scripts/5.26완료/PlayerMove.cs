using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float forwardSpeed;
 
    void Update()
    {
        transform.Translate(0, forwardSpeed, 0); // 앞으로 이동
    }
}
