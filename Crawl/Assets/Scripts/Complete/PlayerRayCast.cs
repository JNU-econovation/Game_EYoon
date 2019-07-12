using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRayCast : MonoBehaviour
{
    Vector3 spawnPosition;
    public GameObject bullet;
    GameObject target;
    int maxDistance = 10;
    private void Start()
    {
        StartCoroutine(Shoot());
    }

    private IEnumerator Shoot()
    {
        while (true)
        {
            yield return new WaitForSeconds(1.0f);
            makeBullet();
        }
    

    }

    void makeBullet()
    {        
        spawnPosition = transform.position + new Vector3(0,30,0);
        // spawnPosition = Camera.main.ScreenToWorldPoint(spawnPosition);     
        print("player " + transform.position + "bullet" + spawnPosition);
        RaycastHit2D hit = Physics2D.Raycast(spawnPosition, transform.forward, maxDistance);
        if (hit)
        {          
            target = hit.transform.gameObject;
            print(target);
            bullet.GetComponent<Bullet>().target = target;
            float dx = spawnPosition.x - transform.position.x;
            float dy = spawnPosition.y - transform.position.y;
            float angle = Mathf.Atan2(dx, dy) * Mathf.Rad2Deg;
            Quaternion rotation = Quaternion.Euler(new Vector3(0, 0, -angle));
            Instantiate(bullet, transform.position, rotation);
            StartCoroutine(BulletDelay());
            Instantiate(bullet, transform.position, rotation);
        }
    }

    IEnumerator BulletDelay()
    {
        yield return new WaitForSeconds(0.3f);
    }




}

/* 
 *  Ray2D rightRay;
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

       */
