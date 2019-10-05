using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Move : MonoBehaviour
{
   float moveSpeed;
    public bool isMoving;
    Vector3 _moveVector;
    Transform _transform;
    JoyStick joyStick;
    private void Start()
    {
        joyStick = GameObject.FindGameObjectWithTag("JoyStick").GetComponent<JoyStick>();
        _transform = transform;
        _moveVector = Vector3.zero;
    }
    void Update()
    {
        HandleInput();
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, 170.0f, 550.0f), transform.position.y, transform.position.z);
    }

    private void FixedUpdate()
    {
        moveSpeed = Player_AbilityManager.Instance.GetMoveSpeed();
        Move();
    }

    public void HandleInput()
    {
        _moveVector = PoolInput();
    }

    public Vector3 PoolInput()
    {
        float h = joyStick.GetHorizontalValue();
        float v = joyStick.GetVerticalValue();
        if (v <= 0)
            v = 0;

        Vector3 moveDir = new Vector3(h, v, 0).normalized;
        return moveDir;
    }

    public void Move()
    {
        _transform.Translate(_moveVector * moveSpeed * Time.deltaTime);
    }
}
