using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float sideSpeed;
    public float forwardSpeed;
 
    void Update()
    {
        transform.Translate(0, forwardSpeed, 0); // 앞으로 이동

        //사이드이동
        if (Input.GetKey(KeyCode.D))
            transform.Translate(sideSpeed * Time.deltaTime * Vector3.right);
        else if (Input.GetKey(KeyCode.A))
            transform.Translate(sideSpeed * Time.deltaTime * Vector3.left);
        else { }
    }
}
