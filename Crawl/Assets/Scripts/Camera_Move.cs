using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Move : MonoBehaviour
{
    GameObject player;
    bool OnBoss;
    private void Awake()
    {
        Screen.SetResolution(720, 1280, true);
    }
    void Start()
    {
        
        player = LevelManager.Instance.GetPlayer();
    }

    // Update is called once per frame
    void Update()
    {
        OnBoss = LevelManager.Instance.OnBoss;
        if(!OnBoss)
            transform.position = new Vector3(360, player.transform.position.y + 128, -0.01f);
        else { }
    }
}
