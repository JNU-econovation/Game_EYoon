using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCam : MonoBehaviour
{
    Transform target;
    public GameObject service;
    public float xDistance;
    public float yDistance;
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
        target = service.GetComponent<LevelManager>().player.transform;
        x = target.position.x - xDistance;
        y = target.position.y - yDistance;
        transform.position = new Vector3(x, y, z);                                   
    }
}
