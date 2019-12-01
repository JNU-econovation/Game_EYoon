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
    Player_Booster player_Booster;
    Player_Circle_Move player_Circle_Move;
    Player _player;
    float yPos;
    bool OnBoss;
    bool bossClear;
    private void Start()
    {
        _player = GetComponent<Player>();
        player_Circle_Move = GetComponentInChildren<Player_Circle_Move>();
        player_Booster = GetComponent<Player_Booster>();
        joyStick = GameObject.FindGameObjectWithTag("JoyStick").GetComponent<JoyStick>();
        _transform = transform;
        _moveVector = Vector3.zero;
    }
    public void DontGoDown_Boss1()
    {
        transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y, 19300.0f, 100000.0f), 0);
    }
    public void DontGoDown_Boss2()
    {
        transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y, 39300.0f, 100000.0f), 0);
    }
    public void DontGoDown_Boss3()
    {
        transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y, 59300.0f, 100000.0f), 0);
    }
    public float GetSpeed()
    {
        return moveSpeed;
    }

    void Update()
    {
        OnBoss = LevelManager.Instance.OnBoss;
        bossClear = LevelManager.Instance.bossClear;
        HandleInput();
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, 170.0f, 550.0f), transform.position.y, transform.position.z);
    }

    private void FixedUpdate()
    {
        if (_player.GetIsPause())
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
        if ((bossClear || !OnBoss) && v <= 0)
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
        if(!player_Booster.GetOnBooster())
            _transform.Translate(_moveVector * moveSpeed * Time.deltaTime);
    }
}
