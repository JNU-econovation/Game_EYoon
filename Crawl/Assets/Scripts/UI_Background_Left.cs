using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Background_Left : MonoBehaviour
{
    MeshRenderer meshRenderer;
    float offset;
    float speed = 0.1f;
    GameObject player;
    Player_Move player_Move;
    float playerSpeed;
    int level;
    public Material[] left_BackGround_Material;
    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        player = LevelManager.Instance.GetPlayer();
        player_Move = player.GetComponent<Player_Move>();
    }

    // Update is called once per frame
    void Update()
    {
        playerSpeed = player_Move.GetSpeed();
        offset += speed * Time.deltaTime * player_Move.GetYpos();
        meshRenderer.material.mainTextureOffset = new Vector2(0, offset);
        level = LevelManager.Instance.level;      
    }
   
}
