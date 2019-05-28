using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public Transform firePosition;
    public GameObject bullet;
    public GameObject trashBullet;
    GameObject target;
    GameObject temp;
    public int NumberOfBullet;
    public Camera cam;
       
    public void Shoot(GameObject obj, Vector3 position) 
    {
        target = obj;
        float dx = position.x - transform.position.x;
        float dy = position.y - transform.position.y;
        float angle = Mathf.Atan2(dx, dy) * Mathf.Rad2Deg;
        Quaternion Rotation = Quaternion.Euler(new Vector3(0, 0, -angle));
        if (target.tag == "Window")
            Instantiate(bullet, firePosition.position, Rotation);
        else    
            Instantiate(trashBullet, firePosition.position, Rotation);           
        

            
        NumberOfBullet--;
    }
    
    void ShootEnemy()
    {

    }

}
