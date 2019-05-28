using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeRay : MonoBehaviour
{
    Camera cam;
    Attack attack;
    public GameObject player;
    public GameObject target;
    Vector3 mousePosition;
    float maxDistance = 15f;

    void Start()
    {
        cam = GetComponent<Camera>();
        attack = player.GetComponent<Attack>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            mousePosition = Input.mousePosition;
            mousePosition = cam.ScreenToWorldPoint(mousePosition);

            RaycastHit2D hit = Physics2D.Raycast(mousePosition, transform.forward, maxDistance);
            if (hit)
            {
                print(1);
                if (hit.collider != null)
                {                  
                    target = hit.collider.gameObject;            
                    attack.Shoot(target, mousePosition);
                }          
            }

        }
    }
}
