using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : Hazard
{
    public GameObject largeWindowFire;
    public GameObject smallWindowFire;
    GameObject fire;
    public float HP;
    public float maxHP;
    public override void Function(GameObject window)
    {
        ChangeWindow(window);
        Destroy(fire, 10.0f);
    }
  
    void ChangeWindow(GameObject window)
    {                
        if (window.name == "window2")
            fire = Instantiate(largeWindowFire);
        else
            fire = Instantiate(smallWindowFire);
        fire.transform.position = window.transform.position;               
    }
    
}
