using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public GameObject NewBullet;
    public GameObject HealTem;
 
    void Start()
    {
        
    }
    public void Bullet()
    {
        NewBullet.transform.position = transform.position;
        Instantiate(NewBullet);
        
    }
    public void Heal()
    {
        HealTem.transform.position = transform.position;
        Instantiate(HealTem);

    }
    
   
}
