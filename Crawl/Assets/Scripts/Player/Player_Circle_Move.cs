using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Player_Circle_Move : MonoBehaviour
{
    [Header("속도, 반지름")]

    float speed;
    [SerializeField]float radius = 1;
    public GameObject player;
    Player _player;
    private float runningTime = 0;
    private Vector2 newPos = new Vector2();
    float centerX;
    float centerY;
    // Use this for initialization
    void Start()
    {
        player = GetComponentInParent<Player>().gameObject;
        _player = player.GetComponent<Player>();
    }
    
    void Update()
    {
        if (_player.GetIsPause())
            speed = 0;
        else
            speed = Player_AbilityManager.Instance.GetAttackSpeed();
        centerX = player.transform.position.x;
        centerY = player.transform.position.y;
        runningTime += Time.deltaTime * speed;
        float x = centerX + radius * Mathf.Cos(runningTime);
        float y = centerY + radius * Mathf.Sin(runningTime);
        newPos = new Vector2(x, y);
        transform.position = newPos;
    }
    public float getRadius()
    {
        return radius;
    }
    public void setRadius(float r)
    {
        radius = r;
    }
}
