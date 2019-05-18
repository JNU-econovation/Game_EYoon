using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    //public Transform target;
    public Image HP;
    public Transform headUp;
   
    void Awake()
    {
        HP.transform.position = headUp.position;
    }
}


