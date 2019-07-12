using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Android;

public class MobileInputManager : MonoBehaviour
{
    Camera cam;
    Attack attack;
    GameObject player;
    public GameObject target;
    Vector3 mousePosition;
    float maxDistance = 15f;
    public float sideSpeed;
    private Vector3 startPos = Vector3.zero;
    private Vector3 endPos = Vector3.zero;
    private Vector3 targetPos = Vector3.zero;

    void Start()
    {
        cam = Camera.main;
        player = GetComponentInParent<LevelManager>().player;
        attack = player.GetComponent<Attack>();       
    }
    
    void FixedUpdate()
    {
      //  Debug.DrawLine(new Vector3(110, transform.position.y), new Vector3(610, transform.position.y));
       
        if(Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Vector3 touchPos = touch.position;
            if (360 - 250 <= touchPos.x && touchPos.x <= 360 + 250)
            {
                PlayerMove(0);
            }
        }

    }
    void PlayerMove(int i)
    {
        Touch touch = Input.GetTouch(i);
        Vector3 touchPos = touch.position;
        Vector3 diffpos;
        if (touch.phase == TouchPhase.Began)
        {
            startPos = touchPos;
        }
        if (touch.phase == TouchPhase.Moved)
        {
            diffpos = new Vector3(touchPos.x - startPos.x, 0.0f, 0.0f);
            startPos = touchPos;
            player.transform.position += diffpos / 10;
        }
    }
    /*
    void ShootBullet(int i)
    {
        Touch touch = Input.GetTouch(i);
        Vector3 touchPos = touch.position;
        if (touch.phase == TouchPhase.Began)
        {
            touchPos = cam.ScreenToWorldPoint(touchPos);

            RaycastHit2D hit = Physics2D.Raycast(touchPos, transform.forward, maxDistance);
            if (hit)
            {
                if (attack.NumberOfBullet > 0)
                {
                    target = hit.collider.gameObject;
                    attack.Shoot(target, touchPos);

                }
            }
        }
    }*/
}

/* 코드 메모
 * if (tpos.y < Screen.height / 10)
                {
                    Vector3 diffpos;
                    if (touch.phase == TouchPhase.Began)
                    {
                        startPos = tpos;
                    }
                    if(touch.phase == TouchPhase.Moved)
                    {
                        diffpos = new Vector3(tpos.x - startPos.x, 0.0f,0.0f);
                        startPos = tpos;
                        player.transform.position += diffpos /5;
                    }
                   
                    */
