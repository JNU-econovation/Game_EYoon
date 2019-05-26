using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCam : MonoBehaviour
{
    public Transform target;
    public float dist;
    float x;
    float y;
    float z;

    void Start()
    {
        x = transform.position.x;
        z = transform.position.z;
    }
    void LateUpdate()
    {
        y = target.position.y - dist;
        transform.position = new Vector3(x, y, z);                                   
    }
}
