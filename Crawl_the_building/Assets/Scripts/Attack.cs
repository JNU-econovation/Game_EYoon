using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public Vector3 mousePosition;
    public Transform firePosition;
    public GameObject bullet;
    GameObject target;
    public int NumberOfBullet;
    public Camera cam;
    private void Start()
    {
        target = cam.GetComponent<Cam>().target;
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {

        if(collider.gameObject == target)
        {
            Destroy(collider.gameObject);
        }
    }
    
    public void Shoot(Vector3 position) 
    {
        mousePosition = position;
        float dx = mousePosition.x - transform.position.x;
        float dy = mousePosition.y - transform.position.y;
        float angle = Mathf.Atan2(dx, dy) * Mathf.Rad2Deg;
        Quaternion Rotation = Quaternion.Euler(new Vector3(0, 0, -angle));
        Instantiate(bullet, firePosition.position, Rotation);
    }
    void ShootEnemy()
    {

    }

}
