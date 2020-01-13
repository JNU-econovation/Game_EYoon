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

        enemys = sea_Enemys;

>>>>>>> 7a48060acd16bcc0cc17bf4c394a53db6452ebbb
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
            if (!LevelManager.Instance.OnBoss && !isPause)
            {
                for (int i = 0; i < Random.Range(1, 3); i++)
                {
                    Instantiate(enemys[SelectEnemy()]);
                }
            }

>>>>>>> 7a48060acd16bcc0cc17bf4c394a53db6452ebbb
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
