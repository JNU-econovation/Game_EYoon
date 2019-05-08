using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCam : MonoBehaviour
{
    public Transform targetTr;
    public float dist = 1.31f;
    
    // Update is called once per frame

    void LateUpdate()
    {

       transform.position = new Vector3(0, targetTr.position.y- dist, -10);
                                 
        
    }
}
