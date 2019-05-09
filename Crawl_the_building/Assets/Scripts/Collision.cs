using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour
{
    public GameObject beforeWindow;
    public GameObject afterWindow;
   
    void Start()
    {
        
        
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "bullet")
        {     
            afterWindow.SetActive(true);
            beforeWindow.SetActive(false);     
        }
    }
    // Update is called once per frame
    void Update()
    {
       
    }

   
}
