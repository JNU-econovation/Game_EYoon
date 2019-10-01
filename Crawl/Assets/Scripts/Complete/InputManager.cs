using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InputManager : Singleton<InputManager>
{
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
