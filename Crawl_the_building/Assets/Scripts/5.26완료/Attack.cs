using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    Transform firePosition;
    public GameObject trashBullet;
    GameObject target;
    public GameObject bullet;
    public int NumberOfBullet;
    private void Start()
    {
      
    }
    public void Shoot(GameObject obj, Vector3 position) 
    {
        print(gameObject.name);
        target = obj;
        bullet.GetComponent<Bullet>().ReferenceTarget(target);

        float dx = position.x - transform.position.x;
        float dy = position.y - transform.position.y;
        float angle = Mathf.Atan2(dx, dy) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.Euler(new Vector3(0, 0, -angle));

        if (target.tag == "Window")
            Instantiate(bullet, transform.position, rotation);
        else
            Instantiate(trashBullet, transform.position, rotation);

        NumberOfBullet--;     
    }
    
    void ShootEnemy()
    {

    }

}
