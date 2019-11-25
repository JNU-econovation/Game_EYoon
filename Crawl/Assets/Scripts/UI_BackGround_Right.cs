using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_BackGround_Right : MonoBehaviour
{
    MeshRenderer meshRenderer;
    float offset;
    float speed = 0.1f;
    GameObject player;
    Player_Move player_Move;
    float playerSpeed;
    int level;
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
        offset += Time.deltaTime * player_Move.GetYpos();
        meshRenderer.material.mainTextureOffset = new Vector2(0, offset);
        level = LevelManager.Instance.level;
        ChangeBackGround();
    }
    public void ChangeBackGround()
    {
        for (int i = 0; i < 3; i++)
        {
            if (level == 0)
            {
                meshRenderer.material = right_BackGround_Material[0];
            }
            else if (level == 1)
            {
                meshRenderer.material = right_BackGround_Material[1];
            }
            else
            {
                meshRenderer.material = right_BackGround_Material[2];
            }
        }



    }
}
