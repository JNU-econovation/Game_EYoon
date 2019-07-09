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
    void Start()
    {
        cam = Camera.main;
        player = GetComponentInParent<LevelManager>().player;
        attack = player.GetComponent<Attack>();
    }

    void Update()
    {
        int count = Input.touchCount;
        if(count > 0)
        { 
            Touch touch = Input.GetTouch(0);
            Vector3 tpos = touch.position;
            if (360 - 250 <= tpos.x && tpos.x <= 360 + 250)
            {
                if (tpos.y < Screen.height / 10)
                {
                    print(tpos);
                    Vector3 firstPos;
                    Vector3 nowPos;
                    Vector3 movePos;
                    if (touch.phase == TouchPhase.Began)
                    {
                        print(tpos);
                    }
                    if(touch.phase == TouchPhase.Moved)
                    {
                        //movePos = tpos - firstPos;
                    }

                }
                else
                {
                    if (touch.phase == TouchPhase.Began)
                    {                        
                        tpos = cam.ScreenToWorldPoint(tpos);

                        RaycastHit2D hit = Physics2D.Raycast(tpos, transform.forward, maxDistance);
                        if (hit)
                        {
                            if (attack.NumberOfBullet > 0)
                            {
                                target = hit.collider.gameObject;
                                attack.Shoot(target, tpos);

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


