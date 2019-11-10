using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] GameObject[] enemys;
    [SerializeField] float[] enemyWeight;
    [SerializeField] float cycleTime;
    List<GameObject> enemy = new List<GameObject>() ;
    bool isPause = false;
    // Start is called before the first frame update
    private void Start()
    {
        StartCoroutine(SpawnEnemy());
        StartCoroutine(PauseTest());
    }
    IEnumerator SpawnEnemy()
    {
        while (true)
        {
            
            

                GameObject spawnEnemy = SelectEnemy();
                if (isPause == false)
                    enemy.Add(Instantiate(spawnEnemy));
                yield return new WaitForSeconds(cycleTime);
            
        }
    }
    public GameObject SelectEnemy()
    {
        float rand = Random.Range(0, 100);
        float sum = 0;
        int i = 0;
        while (i < enemyWeight.Length)
        {
            sum += enemyWeight[i];
            if (rand <= sum)
            {
                return enemys[i];
            }
            i++;
        }
        return enemys[i];
    }
    public void Pause()
    {
        for(int i = 0; i < enemy.Count; i++)
        {
            if(enemy[i] != null)
            enemy[i].GetComponent<Enemy>().Pause();
        }
        Enemy_AttackPattern.Instance.Pause();
        isPause = true;
    }
    public void Resume()
    {
        for (int i = 0; i < enemy.Count; i++)
        {
            if (enemy[i] != null)
                enemy[i].GetComponent<Enemy>().Resume();
        }
        Enemy_AttackPattern.Instance.Resume();
        isPause = false;
    }
    IEnumerator PauseTest()
    {
        yield return new WaitForSeconds(5);
        Pause();
    }
    
}
