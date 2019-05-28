using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashBullet : MonoBehaviour
{
    public float speed;
    void Start()
    {
        
    }
    void Update()
    {
        transform.Translate(Vector3.up * speed);        
    }
}
