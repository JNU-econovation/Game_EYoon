using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    Camera cam;
    Attack attack;
    public GameObject player;
    public GameObject target;
    Vector3 mousePosition;
    float maxDistance = 15f;

    void Start()
    {
        cam = Camera.main;
        attack = player.GetComponent<Attack>();
    }

    void Update()
    {
        //마우스 좌클릭
        if (Input.GetMouseButtonDown(0))
        {
            mousePosition = Input.mousePosition;
            mousePosition = cam.ScreenToWorldPoint(mousePosition);

            RaycastHit2D hit = Physics2D.Raycast(mousePosition, transform.forward, maxDistance);
            if (hit)
            {
                if (attack.NumberOfBullet > 0)
                {
                    if (hit.collider != null)
                    {
                        target = hit.collider.gameObject;
                        attack.Shoot(target, mousePosition);
                    }
                    else
                    {
                        attack.Shoot(null, mousePosition);
                    }
                }
            }

        }
    }
}
