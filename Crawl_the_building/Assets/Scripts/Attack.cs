using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public Vector3 mousePosition;
    public Transform firePosition;
    public GameObject bullet;
    public GameObject windowBullet;
    GameObject target;
    public int NumberOfBullet;

    public void ChooseShoot(GameObject targetObject)
    {
        target = targetObject;
        if (target.tag == "Window")
        {
           // ShootWindow();            
        }
       
    }/*
    void ShootWindow() 
    {
        mousePosition = GetComponent<Cam>().mousePosition;
        float dx = mousePosition.x - transform.position.x;
        float dy = mousePosition.y - transform.position.y;
        float angle = Mathf.Atan2(dx, dy) * Mathf.Rad2Deg;
        Quaternion Rotation = Quaternion.Euler(new Vector3(0, 0, -angle));
        Instantiate(bullet, firePosition.position, Rotation);
    }*/
    void ShootEnemy()
    {

    }

}
