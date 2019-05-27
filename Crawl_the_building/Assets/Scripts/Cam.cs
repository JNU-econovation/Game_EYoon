using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cam : MonoBehaviour
{
    public GameObject player;
    Attack attack;
    Camera cam;
    public GameObject target;
    public Vector3 mousePosition;
    float maxDistance = 15f;
    void Start()
    {
        attack = new Attack();
        target = new GameObject();
        cam = GetComponent<Camera>();
    }

    // Update is called once per frame
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
                    //attack.Shoot(mousePosition);
                }
            }
                
        }
    }
}
