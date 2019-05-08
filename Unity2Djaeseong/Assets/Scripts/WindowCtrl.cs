using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowCtrl : MonoBehaviour
{
   public GameObject brokenWindow;
   Vector3 position;
    int targetExistence = 0;




    // Start is called before the first frame update
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "target")
        {
            targetExistence = 1;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        position =  GetComponent<Transform>().position;
        Quaternion Rotation = Quaternion.Euler(new Vector3(0, 0, 0));
        if (other.gameObject.tag == "bullet"&& targetExistence == 1)
        {
            Instantiate(brokenWindow, position, Rotation);
        }
    }

    
  

}
