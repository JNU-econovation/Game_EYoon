using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : Singleton<EnemyManager>
{
    public GameObject[] enemys;
    [SerializeField] GameObject[] sea_Enemys;
    [SerializeField] GameObject[] sky_Enemys;
    [SerializeField] GameObject[] space_Enemys;
    [SerializeField] float[] enemyWeight;
    [SerializeField] float cycleTime;
    [SerializeField] List<GameObject> spawned_enemy = new List<GameObject>() ;
    [SerializeField] GameObject spawnEnemy;
    bool isPause = false;
    int level;
    // Start is called before the first frame update
    private void Start()
    {
        ChangeEnemy1();
        StartCoroutine(SpawnEnemy());
        //StartCoroutine(PauseTest());
    }

    IEnumerator SpawnEnemy()
    {
        while (true)
        {
           
            if (isPause == false && LevelManager.Instance.OnBoss == false)
            {
                int rand = Random.Range(1, 3);
                if (rand == 1)
                {
                    spawned_enemy.Add(Instantiate(enemys[SelectEnemy()]));
                }
                else
                {
                    spawned_enemy.Add(Instantiate(enemys[SelectEnemy()]));
                    spawned_enemy.Add(Instantiate(enemys[SelectEnemy()]));
                }
            }
            yield return new WaitForSeconds(cycleTime);

        }
    }
 
    public void WeakEnemy(float n)
    {
        for(int i = 0; i < enemys.Length ;i++)
        {
            enemys[i].GetComponent<Enemy_Ability>().Weak(n);
        }
    }
    public int SelectEnemy()
    {
        float rand = Random.Range(0.01f, 100);
        float sum = 0;
        int i = 0;
        while (i < enemyWeight.Length)
        {
            sum += enemyWeight[i];
            if (rand <= sum)
            {
                return i;
            }
            i++;
            
        }
        return i;
    }
    public void ChangeEnemy1()
    {
        enemys = sea_Enemys;
    }
    public void ChangeEnemy2()
    {
        enemys = sky_Enemys;
    }
    public void ChangeEnemy3()
    {
        enemys = space_Enemys;
    }
    public void Pause()
    {
        for(int i = 0; i < spawned_enemy.Count; i++)
        {
            if(spawned_enemy[i] != null)
                spawned_enemy[i].GetComponent<Enemy>().Pause();
        }
        Enemy_AttackPattern.Instance.Pause();
        isPause = true;
    }
    public void Resume()
    {
        for (int i = 0; i < spawned_enemy.Count; i++)
        {
            if (spawned_enemy[i] != null)
                spawned_enemy[i].GetComponent<Enemy>().Resume();
        }
        Enemy_AttackPattern.Instance.Resume();
        isPause = false;
    }
    IEnumerator PauseTest()
    {
        yield return new WaitForSeconds(5);
        Pause();
    }
    IEnumerator ResumeTest()
    {
        yield return new WaitForSeconds(10);
        Resume();
    }


}
