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
    public int level;
    public bool OnBoss;
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
        StartCoroutine(AppearBoss());
    }
    void Update()
    {
        time += Time.deltaTime;
        height = UIManager.Instance.height;
        level = (int)(height / 1000);
        if(OnBoss && level == 0)
        {
            player.transform.position = new Vector3(player.transform.position.x, Mathf.Clamp(player.transform.position.y, 18300.0f, 19100.0f), 0);
        }
    }
    IEnumerator AppearBoss()
    {
        while (true)
        {
            yield return null;
            if (height >= 900 || height >= 1900 || height >= 2900)
            {
                OnBoss = true;
            }
            if (height >= 1000 || height >= 2000 || height >= 3000)
            {
                OnBoss = false;
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
