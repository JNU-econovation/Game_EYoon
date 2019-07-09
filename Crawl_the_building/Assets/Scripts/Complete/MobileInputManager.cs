using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobileInputManager : MonoBehaviour
{
    Camera cam;
    Attack attack;
    GameObject player;
    public GameObject target;
    Vector3 mousePosition;
    float maxDistance = 15f;
    public float sideSpeed;   

    void Start()
    {
        cam = Camera.main;
        player = GetComponentInParent<LevelManager>().player;
        attack = player.GetComponent<Attack>();
    }

    private void Update()
    {
        int right = player.GetComponent<PlayerMove>().rightSpeed;
        int left = player.GetComponent<PlayerMove>().leftSpeed;

        if (Application.platform == RuntimePlatform.Android)
        {
            Vector3 tpos = Input.GetTouch(0).position;
            if (tpos.y <= Screen.height / 9)
            {
                if (tpos.x < Screen.width / 2)
                    player.transform.Translate(sideSpeed * Time.deltaTime * left, 0, 0);
                else if (tpos.x > Screen.width / 2)
                    player.transform.Translate(sideSpeed * Time.deltaTime * right, 0, 0);


            }
            else //총알 발사
            {
                if (Input.GetTouch(0).phase == TouchPhase.Began)
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
}
