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
        GameObject wall;
        if (window.name == "window2")
        {
            blanket = Instantiate(LargeBlanketAnim);
            wall = Instantiate(largeBlanketWall);
        }

        else
        {
            blanket = Instantiate(SmallBlanketAnim);
            wall = Instantiate(smallBlanketWall);
        }
        blanket.transform.position = transform.position;
        wall.transform.position = transform.position;

        Destroy(wall, existTime);
    }   
    
}
