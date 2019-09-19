using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchManager : MonoBehaviour
{
    GameObject joyStick;
    void Start()
    {
        joyStick = GameObject.FindGameObjectWithTag("JoyStick");
    }

   
    void Update()
    {
        //if(Input.touchCount == 1)
        //{
        //    Touch touch = Input.GetTouch(0);
        //    joyStick.transform.position = touch.position;
        //}

        if(Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            Touch touch = Input.GetTouch(0);
            joyStick.transform.position = touch.position;
        }
    }
}
