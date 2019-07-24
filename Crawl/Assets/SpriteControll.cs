using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteControll : MonoBehaviour
{
 
    // Update is called once per frame
    void OnEnable()
    {
        GetComponent<SpriteRenderer>().color = GetComponentInParent<SpriteRenderer>().color;
    }
    
}
