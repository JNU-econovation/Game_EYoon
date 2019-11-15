using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Move : MonoBehaviour
{
    GameObject player;
    void Start()
    {
        player = LevelManager.Instance.GetPlayer();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(360, player.transform.position.y + 128, -0.01f); 
    }
}
