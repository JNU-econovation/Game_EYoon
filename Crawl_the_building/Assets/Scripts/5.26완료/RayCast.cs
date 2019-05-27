using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCast : MonoBehaviour
{
    Camera cam;
    public GameObject player;
    public GameObject target;
    Vector3 mousePosition;
    float maxDistance = 15f;
    void Start()
    {
        cam = GetComponent<Camera>();
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
                if (hit.collider != null)
                {
                    target = hit.collider.gameObject;
                    player.GetComponent<Attack>().Shoot(mousePosition);                   
                }
            }

        }
    }
}
