using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InputManager : Singleton<InputManager>
{
    Camera cam;
    Attack attack;
    GameObject player;
    public GameObject target;
    Vector3 mousePosition;
    float maxDistance = 15f;
    public float sideSpeed;
    public float rightSpeed;
    public float leftSpeed;
    float rightReverseSpeed;
    float leftReverseSpeed;
    float originRightSpeed;
    float originLeftSpeed;
    public bool isReverse = false;
    void Start()
    {
        cam = Camera.main;
        player = GetComponentInParent<LevelManager>().player;
        attack = player.GetComponent<Attack>();
        originRightSpeed = rightSpeed;
        originLeftSpeed = leftSpeed;
        rightReverseSpeed = rightSpeed * -1.0f;
        leftReverseSpeed = leftSpeed * -1.0f;
    }

    public void ChangeSideMove()
    {
        if(isReverse == true)
        {
            rightSpeed = rightReverseSpeed;
            leftSpeed = leftReverseSpeed;           
        }
        else
        {
            rightSpeed = originRightSpeed;
            leftSpeed = originLeftSpeed;
        }
        
    }

    
    void Update()
    {       
        if (Input.GetKey(KeyCode.D))
        {
            player.transform.Translate(Time.deltaTime * Vector3.right * rightSpeed);
        }
           
        else if (Input.GetKey(KeyCode.A))
        {
            player.transform.Translate(Time.deltaTime * Vector3.left * leftSpeed);
        }
    
                        
        
    }

}

/*//마우스 좌클릭
        if (Input.GetMouseButtonDown(0))
        {
            mousePosition = Input.mousePosition;
            mousePosition = cam.ScreenToWorldPoint(mousePosition);
            
            RaycastHit2D hit = Physics2D.Raycast(mousePosition, transform.forward, maxDistance);
            if (hit)
            {
                if (attack.NumberOfBullet > 0)
                {
                    target = hit.collider.gameObject;
                    attack.Shoot(target, mousePosition);
                                       
                }
            }
            
        }
        */
/* 모바일 구동
 * if (Application.platform == RuntimePlatform.Android)
     {
         Vector3 tpos = Input.GetTouch(0).position;
         if (tpos.y <= Screen.height / 9)
         {
             // 캐릭터 이동
         }
         else //총알 발사
         {
             if (Input.GetTouch(0).phase == TouchPhase.Began)
             {
                 Vector3 pos = Input.GetTouch(0).position;
                 pos = cam.ScreenToWorldPoint(pos);

                 RaycastHit2D hit = Physics2D.Raycast(pos, transform.forward, maxDistance);
                 if (hit)
                 {
                     if (attack.NumberOfBullet > 0)
                     {
                         target = hit.collider.gameObject;
                         attack.Shoot(target, pos);

                     }
                 }

             }
         }
     }*/

/* 메모
 *  int count = Input.touchCount;
    if (count == 0) return;
    bool begin, move, end;
    begin = move = end = false;

    ArrayList result = new ArrayList();
    for(int i = 0; i < count; i++)
    {
        Touch touch = Input.GetTouch(i);
        result.Add(touch);
        if (touch.phase == TouchPhase.Began && touchBegin != null) begin = true;
        else if (touch.phase == TouchPhase.Moved && touchMove != null) move = true;
        else if (touch.phase == TouchPhase.Ended && touchEnd != null) end = true;           
    }

    if (begin) touchBegin(result);
    if (end) touchEnd(result);
    if (move) touchMove(result);
*/
