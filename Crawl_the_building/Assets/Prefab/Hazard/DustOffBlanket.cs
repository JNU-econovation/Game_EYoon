using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DustOffBlanket : Hazard
{
    Vector3 playerTr;
    float playerYpos;
    float blanketYpos;
    int existTime = 3;
    public GameObject largeBlanketCol;
    public GameObject smallBlanketCol;
    public GameObject LargeBlanketAnim;
    public GameObject SmallBlanketAnim;
    public override void Function(GameObject window)
    {
        GameObject blanket;
        GameObject wall;
        if (window.name == "window2")
        {
            blanket = Instantiate(LargeBlanketAnim);
            wall = Instantiate(largeBlanketCol);
        }

        else
        {
            blanket = Instantiate(SmallBlanketAnim);
            wall = Instantiate(smallBlanketCol);
        }
        blanket.transform.position = transform.position;
        wall.transform.position = transform.position;

        Destroy(wall, existTime);
    }   
    
}
