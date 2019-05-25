using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCam : MonoBehaviour
{
    public Transform targetTr;
    public float dist;
    
    void LateUpdate()
    {
       transform.position = new Vector3(360, targetTr.position.y- dist, -10);                                   
    }
}
