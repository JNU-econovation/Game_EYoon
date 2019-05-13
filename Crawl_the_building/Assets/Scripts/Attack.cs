using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public Vector3 mousePosition;
    public Transform firePosition;
    [SerializeField]
    Camera Camera;
    public GameObject bullet;
    public GameObject target;
    Transform bulletPosition;
    public int speed;
    public float attackDelay;
    bool isHit;

    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetMouseButtonDown(0) )
        {

            attack();
        }



    }

   void attack()
    {
        
        mousePosition = Camera.ScreenToWorldPoint(Input.mousePosition);
        float dx = mousePosition.x - transform.position.x;
        float dy = mousePosition.y - transform.position.y;
        float angle = Mathf.Atan2(dx, dy) * Mathf.Rad2Deg;
        Quaternion Rotation = Quaternion.Euler(new Vector3(0, 0, -angle));
        Instantiate(bullet, firePosition.position, Rotation);
       
        
        
    }

}
