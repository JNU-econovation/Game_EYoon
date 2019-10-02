using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Move : MonoBehaviour
{
    GameObject service;
    GameObject player;
    Player_Move player_move;
    Vector3 _moveVector;
    Transform _transform;
    void Start()
    {
        service = GameObject.FindGameObjectWithTag("Service");
        
       
    }


    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
        //    Camera.main.transform.Translate(0, 150, 0);
        }
    }
}
