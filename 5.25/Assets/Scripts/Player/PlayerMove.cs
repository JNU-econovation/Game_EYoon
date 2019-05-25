using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] float sideMove;
    [SerializeField] float forwardSpeed;
 
    void Update()
    {
        transform.Translate(0, forwardSpeed, 0);

        if (Input.GetKey(KeyCode.D))
            transform.Translate(sideMove * Time.deltaTime, 0, 0);
     
        if (Input.GetKey(KeyCode.A))
            transform.Translate(-sideMove * Time.deltaTime, 0, 0);
    }
}
