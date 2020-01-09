using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : Singleton<EnemyManager>
{
    public GameObject[] enemys;
    public GameObject[] sea_Enemys;
    public GameObject[] sky_Enemys;
    public GameObject[] space_Enemys;
    [SerializeField] float[] enemyWeight;
    [SerializeField] float cycleTime;
    [SerializeField] GameObject spawnEnemy;
    public bool isPause = false;
    int level;
    private void Start()
    {
<<<<<<< HEAD
        enemys = sea_Enemys;
=======
        ChangeEnemy1();
>>>>>>> 75cf88a30bdfa28637f3ffc3deb5b6d007dcf14a
        StartCoroutine(SpawnEnemy());
    }

    IEnumerator SpawnEnemy()
    {
        while (true)
<<<<<<< HEAD
        {        
            if(!LevelManager.Instance.OnBoss || !isPause)
                Instantiate(enemys[SelectEnemy()]);
=======
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
>>>>>>> 75cf88a30bdfa28637f3ffc3deb5b6d007dcf14a
            yield return new WaitForSeconds(cycleTime);

        }
    }
 
    public void WeakEnemy(float n)
    {
        for(int i = 0; i < enemys.Length ;i++)
        {
            sea_Enemys[i].GetComponent<Enemy_Ability>().Weak(n);
            sky_Enemys[i].GetComponent<Enemy_Ability>().Weak(n);
            space_Enemys[i].GetComponent<Enemy_Ability>().Weak(n);
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
        isPause = true;
    }
    public void Resume()
    {     
        isPause = false;
    }


}
