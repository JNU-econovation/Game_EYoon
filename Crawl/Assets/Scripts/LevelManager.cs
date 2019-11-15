using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : Singleton<LevelManager>
{
    public GameObject playerPrefab;
    GameObject player;
    Player_Move player_Move;
    Player_Bomb_Attack bomb_Attack;
    bool[] stage = new bool[3];
    float time = 0;
    public GameObject[] left_backGround;
    public GameObject[] right_backGround;
    void Awake()
    {
        stage[0] = true;
        player = playerPrefab;
        //player = Instantiate(playerPrefab);
        player_Move = player.GetComponent<Player_Move>();
        bomb_Attack = player.GetComponent<Player_Bomb_Attack>();
        
    }
    private void Start()
    {
    }
    void Update()
    {
        time += Time.deltaTime;
    }

    public GameObject GetPlayer()
    {
        return player;
    }

    public void Pause()
    {
        EnemyManager.Instance.Pause();
        player_Move.Pause();
        bomb_Attack.Pause();

    }
    public void Resume()
    {
        EnemyManager.Instance.Resume();
        player_Move.Resume();
        bomb_Attack.Resume();
    }
    public void ChangeStage()
    {
        for(int i = 0; i< stage.Length; i++)
        {
            if(stage[0])
            {               
                stage[0] = false;
                stage[1] = true;
                stage[2] = false;
                break;
            }
            else if(stage[1])
            {               
                stage[0] = false;
                stage[1] = false;
                stage[2] = true;
                break;
            }
            else
            {

            }
        }
    }
    public bool[] GetStage()
    {
        return stage;
    }
}
