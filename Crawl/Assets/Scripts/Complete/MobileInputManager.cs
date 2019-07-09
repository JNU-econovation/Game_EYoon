using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Android;

public class MobileInputManager : MonoBehaviour
{
    KeyCode A = KeyCode.A;
    KeyCode D = KeyCode.D;
    Camera cam;
    Attack attack;
    GameObject player;
    public GameObject target;
    Vector3 mousePosition;
    float maxDistance = 15f;
    public float sideSpeed;
    public Sprite image;
    public Sprite image2;

    private Vector3 startPos = Vector3.zero;
    private Vector3 endPos = Vector3.zero;
    private Vector3 targetPos = Vector3.zero;
    float deltaX, deltaY;
    Rigidbody2D rb;
    private bool isClicked = false;
    void Start()
    {
        cam = Camera.main;
        player = GetComponentInParent<LevelManager>().player;
        attack = player.GetComponent<Attack>();
        rb = player.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        int count = Input.touchCount;
        if(count > 0)
        { 
            Touch touch = Input.GetTouch(0);
            Vector3 touchPos = touch.position;
            if (360 - 250 <= touchPos.x && touchPos.x <= 360 + 250)
            {

                if (touchPos.y < Screen.height / 10)
                {
               //     touchPos = Camera.main.ScreenToWorldPoint(touch.position);
                    switch (touch.phase)
                    {
                        case TouchPhase.Began:
                            deltaX = touchPos.x - player.transform.position.x;         
                            break;
                        case TouchPhase.Moved:
                            rb.MovePosition(new Vector2(touchPos.x - deltaX, 0));
                            break;
                        case TouchPhase.Ended:
                            rb.velocity = Vector2.zero;
                            break;
                    }

                }
                else
                {
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

                }

            }                       
            
        }                   

        int right = player.GetComponent<PlayerMove>().rightSpeed;
        int left = player.GetComponent<PlayerMove>().leftSpeed;        
        if (Input.GetKey(KeyCode.D))
            player.transform.Translate(sideSpeed * Time.deltaTime * Vector3.right * right);
        else if (Input.GetKey(KeyCode.A))
            player.transform.Translate(sideSpeed * Time.deltaTime * Vector3.left * left);

        


        }
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
