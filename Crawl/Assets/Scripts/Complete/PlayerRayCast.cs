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
    RaycastHit2D downHit;
    
    float upDistance = 1.0f;
    float sideDistance = 7.0f;
    [SerializeField] LayerMask UpBlanketLayer;
    [SerializeField] LayerMask RightBlanketLayer;
    [SerializeField] LayerMask LeftBlanketLayer;



    float originalLeftSpeed;
    float originalRightSpeed;
    float originalUpSpeed;

    private void Start()
    {
        originalLeftSpeed = InputManager.Instance.leftSpeed;
        originalRightSpeed = InputManager.Instance.rightSpeed;
        originalUpSpeed = GetComponent<PlayerMove>().forwardSpeed;
    }

    private void Update()
    {

        rightRay = new Ray2D(transform.position, Vector2.right);
        leftRay = new Ray2D(transform.position, Vector2.left);
        upRay = new Ray2D(transform.position, Vector2.down);
        
        rightHit = Physics2D.Raycast(transform.position, Vector2.right, sideDistance, RightBlanketLayer);
        leftHit = Physics2D.Raycast(transform.position, Vector2.left, sideDistance, LeftBlanketLayer);
        downHit = Physics2D.Raycast(transform.position, Vector2.down, upDistance, UpBlanketLayer);


        //if (rightHit)
        //    rightHit.collider.gameObject.GetComponent<BlanketAnim>().ActiveFunction();
        //else
        //    rightHit.collider.gameObject.GetComponent<BlanketAnim>().InactiveFunction();
        
        //if (leftHit)
        //    rightHit.collider.gameObject.GetComponent<BlanketAnim>().Function();


        //else
        //    InputManager.Instance.leftSpeed = originalLeftSpeed;
        //if (downHit)
        //    rightHit.collider.gameObject.GetComponent<BlanketAnim>().Function();
        //else
        //    GetComponent<PlayerMove>().forwardSpeed = originalUpSpeed;



    }




}
