using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    GameObject target;
    public GameObject trashBullet;
    public GameObject bullet;
    public int NumberOfBullet;

    private void Start()
    {
        NumberOfBullet = 30;
    }
    public void Shoot(GameObject targetObj, Vector3 mousePosition) 
    {
        target = targetObj;
        bullet.GetComponent<Bullet>().ReferenceTarget(target); //bullet 스크립트에도 타겟 전달

        float dx = mousePosition.x - transform.position.x;
        float dy = mousePosition.y - transform.position.y;
        float angle = Mathf.Atan2(dx, dy) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.Euler(new Vector3(0, 0, -angle));

        if (target.tag == "Window")
        {       
            Instantiate(bullet, transform.position, rotation);
        }
        else
            Instantiate(trashBullet, transform.position, rotation);

        NumberOfBullet--;     
    }
}
