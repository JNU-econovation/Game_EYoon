using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DustOffBlanket : Hazard
{
    Vector3 playerTr;
    float playerYpos;
    float blanketYpos;
    int existTime = 4;
    public GameObject largeBlanketWall;
    public GameObject smallBlanketWall;
    public GameObject LargeBlanketAnim;
    public GameObject SmallBlanketAnim;
    public override void Function(GameObject window)
    {
        GameObject blanket;
        if (window.name == "window2")
        {
            blanket = Instantiate(LargeBlanketAnim);
            blanket.GetComponent<LargeBlanketAnim>().Function(window);
        }

        else
        {
            blanket = Instantiate(SmallBlanketAnim);
            blanket.GetComponent<SmallBlanketAnim>().Function(window);
        }
        blanket.transform.position = transform.position;
  
    }   
    
}
