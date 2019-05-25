using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public Vector3 mousePosition;
    public Transform firePosition;
    [SerializeField]
    Camera Camera;
    [SerializeField] GameObject bullet;
    [SerializeField] GameObject windowBullet;
    GameObject target;
    public int NumberOfBullet;
    GameObject changer;
    public int windowHP;

    void Start()
    {
        windowHP = GetComponent<WindowChanger>().WindowHp;
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && NumberOfBullet > 0) //잔여총알 존재, 마우스 클릭시 실행
        {           
            CastRay(); 
        }   
    }

    void CastRay() 
    {
        target = null;
       
        Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        RaycastHit2D hit = Physics2D.Raycast(pos, Vector2.zero, 10f);

        if (hit.collider != null && windowHP > 0)
        {
            target = hit.collider.gameObject; //마우스가 위치한 타겟

            if (target.tag == "Window") //타겟이 창문
            {
                target.tag = "targetWindow"; 
                Debug.Log(target.tag);
                windowAttack();
                
                NumberOfBullet--; //총알 개수 감소
            }
                        
        }
        else
        {
            attack();
            NumberOfBullet--;
        }
       
    }

   void attack()
    {   
        mousePosition = Camera.ScreenToWorldPoint(Input.mousePosition);
        float dx = mousePosition.x - transform.position.x;
        float dy = mousePosition.y - transform.position.y;
        float angle = Mathf.Atan2(dx, dy) * Mathf.Rad2Deg;
        Quaternion Rotation = Quaternion.Euler(new Vector3(0, 0, -angle));
        Instantiate(bullet, firePosition.position, Rotation);
    }
    void windowAttack()
    {
        mousePosition = Camera.ScreenToWorldPoint(Input.mousePosition);
        float dx = mousePosition.x - transform.position.x;
        float dy = mousePosition.y - transform.position.y;
        float angle = Mathf.Atan2(dx, dy) * Mathf.Rad2Deg;
        Quaternion Rotation = Quaternion.Euler(new Vector3(0, 0, -angle));
        Instantiate(windowBullet, firePosition.position, Rotation);
    }


}
