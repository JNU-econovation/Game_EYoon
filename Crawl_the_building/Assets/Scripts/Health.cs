using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [SerializeField] Transform target;
    public Vector3 offset; //캐릭터와 체력바의 간격
    void Awake()
    {
        transform.position = new Vector3(target.position.x, target.position.y, 0) + offset; 
    }
   
}
