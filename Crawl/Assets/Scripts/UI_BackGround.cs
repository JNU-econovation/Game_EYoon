using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_BackGround : MonoBehaviour
{
    MeshRenderer meshRenderer;
    float offset;
    float speed = 0.1f;
    GameObject player;
    Player_Move player_Move;
    float playerSpeed;
    bool[] stage;
    public bool left;
    public Material[] left_BackGround_Material;
    public Material[] right_BackGround_Material;
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
        stage = LevelManager.Instance.GetStage();
        for(int i = 1; i < stage.Length; i++)
        {
            if (stage[i])
            {
                if(left)
                    meshRenderer.material = left_BackGround_Material[i];
                else
                    meshRenderer.material = right_BackGround_Material[i];
            }
        }
    }
}
