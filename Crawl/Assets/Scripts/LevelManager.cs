using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : Singleton<LevelManager>
{
    public GameObject playerPrefab;
    GameObject player;
    Player_Move player_Move;
    Player_Bomb_Attack bomb_Attack;
    Player _player;
    float time = 0;
    float height;
    float p;
    public int level;
    public bool OnBoss;
    public bool bossClear;
    public GameObject[] boss;
    public GameObject[] left_BackGround;
    public GameObject[] right_BackGround;
    public Material[] right_BackGround_Material;
    public Material[] left_BackGround_Material;
    void Awake()
    {
        player = playerPrefab;
        _player = player.GetComponent<Player>();
        //player = Instantiate(playerPrefab);
        player_Move = player.GetComponent<Player_Move>();
        bomb_Attack = player.GetComponent<Player_Bomb_Attack>();
        
    }
    private void Start()
    {
        StartCoroutine(LevelUp());
        StartCoroutine(LevelUp2());
        StartCoroutine(LevelUp3());
        StartCoroutine(AppearBoss1());
        StartCoroutine(AppearBoss2());
        StartCoroutine(AppearBoss3());
    }
    void Update()
    {
        time += Time.deltaTime;
        height = UIManager.Instance.height;
        level = (int)(height / 1000);

        if (OnBoss)
        {
            if (!bossClear && level == 0)
            {
                player.transform.position = new Vector3(player.transform.position.x, Mathf.Clamp(player.transform.position.y, 19300.0f, 20000.0f), 0);
            }          
            else if (!bossClear && level == 1)
            {
                player.transform.position = new Vector3(player.transform.position.x, Mathf.Clamp(player.transform.position.y, 39300.0f, 40000.0f), 0);
            }       
            else if (!bossClear && level == 2)
            {
                player.transform.position = new Vector3(player.transform.position.x, Mathf.Clamp(player.transform.position.y, 59300.0f, 60000.0f), 0);
            }           
        }
               
    }
    IEnumerator ChangeEnemy_By_Level()
    {
        while (true)
        {
            yield return null;
            float color_R;
            float color_G;
            float color_B;
            if (level % 3 == 0)
            {
                color_R = 255;
                color_G = 0;
                color_B = 0;
            }else if(level % 3 == 1)
            {
                color_R = 0;
                color_G = 255;
                color_B = 0;
            }
            else
            {
                color_R = 0;
                color_G = 0;
                color_B = 255;
            }
            float hp = level * 200;
            float damage = level * 20;
            GameObject[] enemys = EnemyManager.Instance.enemys;
            for(int i = 0; i < enemys.Length; i++)
            {
               
            }
            
        }
    }
    IEnumerator LevelUp()
    {
        while (true)
        {
            yield return null;
            if(level == 1)
            {
                bossClear = false;
                OnBoss = false;
                for (int i = 0; i < 3; i++)
                {
                    left_BackGround[i].GetComponent<MeshRenderer>().material = left_BackGround_Material[1];
                    right_BackGround[i].GetComponent<MeshRenderer>().material = right_BackGround_Material[1];
                }
                break;
            }
        }
    }
    IEnumerator LevelUp2()
    {
        while (true)
        {
            yield return null;
            if (level == 2)
            {
                bossClear = false;
                OnBoss = false;
                for (int i = 0; i < 3; i++)
                {
                    left_BackGround[i].GetComponent<MeshRenderer>().material = left_BackGround_Material[2];
                    right_BackGround[i].GetComponent<MeshRenderer>().material = right_BackGround_Material[2];
                }
                break;
            }
        }
    }
    IEnumerator LevelUp3()
    {
        while (true)
        {
            yield return null;
            if (level == 3)
            {
                bossClear = false;
                OnBoss = false;
                break;
            }
        }
    }
    IEnumerator AppearBoss1()
    {
        while (true)
        {
            yield return null;
            if (height >= 955)
            {
                OnBoss = true;
                Instantiate(boss[0]);
                break;
            }           
        }
    }
    IEnumerator AppearBoss2()
    {
        while (true)
        {
            yield return null;
            if (height >= 1955)
            {
                OnBoss = true;
                Instantiate(boss[1]);
                break;
            }
        }
    }
    IEnumerator AppearBoss3()
    {
        while (true)
        {
            yield return null;
            if (height >= 2955)
            {
                OnBoss = true;
                Instantiate(boss[2]);
                break;
            }
        }
    }
    public GameObject GetPlayer()
    {
        return player;
    }


    public void Pause()
    {
        EnemyManager.Instance.Pause();
        _player.Pause();
        bomb_Attack.Pause();

    }
    public void Resume()
    {
        EnemyManager.Instance.Resume();
        _player.Resume();
        bomb_Attack.Resume();
    }
    
}
