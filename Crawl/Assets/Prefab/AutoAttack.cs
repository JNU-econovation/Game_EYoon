using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoAttack : MonoBehaviour
{
    GameObject target;
    public GameObject bullet;
    public GameObject window1;
    public GameObject window2;
    public GameObject window3;
    void Start()
    {
     //   StartCoroutine(AutoShoot());
    }

    IEnumerator AutoShoot()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.2f);
            Shoot();
        }
        
    }

    public void Shoot()
    {
        Instantiate(bullet, transform.position, Quaternion.identity);
    }
    
   
}
