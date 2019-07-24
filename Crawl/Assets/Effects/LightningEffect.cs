using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightningEffect : Effect
{
    public GameObject[] startObject;
    public GameObject endObject;
    public GameObject warning;

  
    public void DesignatePosition()
    {
       
        int rand = Random.Range(0, 3);
        for(int i = 0; i < startObject.Length; i++)
        {
            startObject[i].transform.position = new Vector3(Camera.main.transform.position.x - 30 + (30 * i), Camera.main.transform.position.y + 200, 0);
        }
        startObject[0].transform.position = startObject[rand].transform.position;
        endObject.transform.position = warning.transform.position;
    }
}
