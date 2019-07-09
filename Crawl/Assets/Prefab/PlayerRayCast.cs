using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRayCast : MonoBehaviour
{
    Ray2D rightRay;
    Ray2D leftRay;
    Ray2D upRay;
   
    RaycastHit2D rightHit;
    RaycastHit2D leftHit;
    RaycastHit2D upHit;
    
    float distance = 1.0f;
    [SerializeField] LayerMask blanketLayerMask;

    private void Update()
    {

        rightRay = new Ray2D(transform.position, Vector2.right);
        leftRay = new Ray2D(transform.position, Vector2.left);
        upRay = new Ray2D(transform.position, Vector2.up);
        
        rightHit = Physics2D.Raycast(transform.position, Vector2.right, distance, blanketLayerMask);
        leftHit = Physics2D.Raycast(transform.position, Vector2.left, distance, blanketLayerMask);
        upHit = Physics2D.Raycast(transform.position, Vector2.up, distance, blanketLayerMask);
        

        if (rightHit)
            GetComponent<PlayerMove>().rightSpeed = 0;
        else
            GetComponent<PlayerMove>().rightSpeed = 1;
        if (leftHit)
            GetComponent<PlayerMove>().leftSpeed = 0;
        else
            GetComponent<PlayerMove>().leftSpeed = 1;
        if (upHit)
            GetComponent<PlayerMove>().forwardSpeed = 0;
        else
            GetComponent<PlayerMove>().forwardSpeed = 1;
            

        
    }




}
