using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DustOffBlanket : Hazard
{
    Vector3 playerTr;
    float playerYpos;
    float blanketYpos;
    int existTime = 4;
    public GameObject LargeBlanketAnim;
    public GameObject SmallBlanketAnim;
    public override void Function(GameObject window)
    {
        GameObject blanket;
        //if (window.name == "window2")
        //{
        //    blanket = Instantiate(LargeBlanketAnim);

        //}

        //else
        //{
        //    blanket = Instantiate(SmallBlanketAnim);
        
        //}
        //blanket.transform.position = transform.position;
  
    }   
    
}
