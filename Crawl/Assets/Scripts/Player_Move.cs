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
    Player_Circle_Move player_Circle_Move;
    bool isPause;
    float yPos;
    private void Start()
    {
        player_Circle_Move = GetComponentInChildren<Player_Circle_Move>();
        joyStick = GameObject.FindGameObjectWithTag("JoyStick").GetComponent<JoyStick>();
        _transform = transform;
        _moveVector = Vector3.zero;
    }
    public float GetSpeed()
    {
        return moveSpeed;
    }
    public void Pause()
    {
        isPause = true;
        player_Circle_Move.Pause();
    }
    public void Resume()
    {
        isPause = false;
        player_Circle_Move.Resume();
    }
    void Update()
    {
        HandleInput();
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, 170.0f, 550.0f), transform.position.y, transform.position.z);
    }

    private void FixedUpdate()
    {
        if (isPause)
            moveSpeed = 0;
        else
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
        yPos = v;
        Vector3 moveDir = new Vector3(h, v, 0).normalized;
        return moveDir;
    }

    public float GetYpos()
    {
        return yPos;
    }
    public void Move()
    {
        _transform.Translate(_moveVector * moveSpeed * Time.deltaTime);
    }
}
