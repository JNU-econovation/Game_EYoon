using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchListener : InputManager
{
    float beginX, beginY;
    void Start()
    {

        touchMove += (touches) => { Debug.Log("move"); };
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
