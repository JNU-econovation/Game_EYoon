using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
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

    void Update()
    {
        if (Input.GetKey(KeyCode.D))
            player.transform.Translate(sideSpeed * Time.deltaTime * Vector3.right);
        else if (Input.GetKey(KeyCode.A))
            player.transform.Translate(sideSpeed * Time.deltaTime * Vector3.left);
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
