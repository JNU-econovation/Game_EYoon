using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : Hazard
{
    public GameObject largeWindowFire;
    public GameObject smallWindowFire;
    GameObject fire;

    public override void Function(GameObject window)
    {
        gameObject.SetActive(false);
        ChangeWindow(window);        
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
