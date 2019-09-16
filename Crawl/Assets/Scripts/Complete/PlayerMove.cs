using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class PlayerMove : MonoBehaviour
{
    public float forwardSpeed;
    public float originforwardSpeed;
    float xPos;
    public GameObject playerNearMap;
    public GameObject nextMap;
    public GameObject[] map;
    public bool isCenter = false;
    public float playerHeight;
    public GameObject joyStick;
    public float moveSpeed;
    Vector3 _moveVector;
    Transform _transform;
    private void Start()
    {
        joyStick = GameObject.FindGameObjectWithTag("JoyStick");
        originforwardSpeed = forwardSpeed;
        playerNearMap = WindowList.Instance.map[0];
        nextMap = WindowList.Instance.map[1];
        _transform = transform;
        _moveVector = Vector3.zero;
    }
    void Update()
    {
        HandleInput();
        playerHeight = transform.position.y / 10.0f;
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, 300.0f, 420.0f), transform.position.y, transform.position.z);
      /*  transform.position = new Vector3(xPos, transform.position.y, transform.position.z); // 앞으로 이동  
        if (Time.timeScale != 0)
        {
            transform.Translate(0, forwardSpeed, 0);
        }*/
        if (transform.position.y >= 200)
            if (350 <= transform.position.x && transform.position.x <= 370)
                isCenter = true;
            else
                isCenter = false;
    }

    private void FixedUpdate()
    {
        Move();
    }

    public void HandleInput()
    {
        _moveVector = poolInput();
    }

    public Vector3 poolInput()
    {
        float h = joyStick.GetComponent<Player_JoyStick>().GetHorizontalValue();
        float v = joyStick.GetComponent<Player_JoyStick>().GetVerticalValue();
        if (v <= 0)
            v = 0;
        Vector3 moveDir = new Vector3(h, v, 0).normalized;
        return moveDir;
    }
    public void Move()
    {
        _transform.Translate(_moveVector * moveSpeed * Time.deltaTime);
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
