using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    GameObject target;   
    public GameObject bullet;
    public int NumberOfBullet;

    private void Start()
    {
        NumberOfBullet = 100;
    }   

    public void Shoot(GameObject target, Vector3 mousePosition) 
    {
        bullet.GetComponent<Bullet>().target = target;
        float dx = mousePosition.x - transform.position.x;
        float dy = mousePosition.y - transform.position.y;
        float angle = Mathf.Atan2(dx, dy) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.Euler(new Vector3(0, 0, -angle));        
            Instantiate(bullet, transform.position, rotation);
                   
        NumberOfBullet--;     
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {        
        if (collider.gameObject.tag == "Block")
        {
            GameObject block = collider.gameObject;
            gameObject.GetComponent<Health>().hp -= block.GetComponent<Block>().damage;
            Destroy(block);
        } 
    }
}
