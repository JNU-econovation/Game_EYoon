using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float forwardSpeed;
    float xPos;
    public GameObject playerNearMap;
    public GameObject nextMap;
    public GameObject[] map;
    public int rightSpeed;
    public int leftSpeed;

    void Update()
    {
        xPos = Mathf.Clamp(transform.position.x, 330.0f, 390.0f);
        transform.position = new Vector3(xPos, transform.position.y, transform.position.z);
        transform.Translate(0, forwardSpeed, 0); // 앞으로 이동                   
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "map1")
        {
            playerNearMap = map[0];
            nextMap = map[1];
        }
        if (collider.tag == "map2")
        {
            playerNearMap = map[1];
            nextMap = map[2];
        }
        if (collider.tag == "map3")
        {
            playerNearMap = map[2];
            nextMap = map[0];
        }
           
    }
}
