using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_SatelliteBulletRotater : MonoBehaviour
{
    [SerializeField] GameObject bullet;
    [SerializeField] int bulletCount;
    float speed = 2;
    [SerializeField] float r;
    bool rotate = false;
    private void Start()
    {
        for(int i = 0; i< bulletCount; i++)
        {
            GameObject satellite = Instantiate(bullet, transform.position, Quaternion.Euler(0, 0, 360 / bulletCount * (i)));
            satellite.transform.parent = gameObject.transform;
            satellite.transform.Translate(Vector3.right*r);
            satellite.transform.parent = gameObject.transform;
        }
        StartRotate();
        
    }
    private void Update()
    {
        if(rotate == true)
        {
            transform.Rotate(0, 0, speed);
        }
    }

    void StartRotate()
    {
        rotate = true;  
    }
}
