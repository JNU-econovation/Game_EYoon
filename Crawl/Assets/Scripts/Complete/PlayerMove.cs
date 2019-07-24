using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float forwardSpeed;
    public float originforwardSpeed;
    float xPos;
    public GameObject playerNearMap;
    public GameObject nextMap;
    public GameObject[] map;
    public bool isCenter = false;
    private void Start()
    {
        originforwardSpeed = forwardSpeed;
        playerNearMap = WindowList.Instance.map[0];
        nextMap = WindowList.Instance.map[1];
    }
    void Update()
    {
      
        xPos = Mathf.Clamp(transform.position.x, 300.0f, 420.0f);
        transform.position = new Vector3(xPos, transform.position.y, transform.position.z); // 앞으로 이동  
        if (Time.timeScale != 0)
        {
            transform.Translate(0, forwardSpeed, 0);
        }
        if (transform.position.y >= 200)
            if (350 <= transform.position.x && transform.position.x <= 370)
                isCenter = true;
            else
                isCenter = false;
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "map1")
        {
            playerNearMap = WindowList.Instance.map[0];
            nextMap = WindowList.Instance.map[1];
        }
        if (collider.tag == "map2")
        {
            playerNearMap = WindowList.Instance.map[1];
            nextMap = WindowList.Instance.map[2];
        }
        if (collider.tag == "map3")
        {
            playerNearMap = WindowList.Instance.map[2];
            nextMap = WindowList.Instance.map[0];
        }
           
    }
}
