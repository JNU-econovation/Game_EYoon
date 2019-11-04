using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] GameObject[] enemys;
    [SerializeField] float[] enemyWeight;
    [SerializeField] float cycleTime;
    // Start is called before the first frame update
    private void Start()
    {
        StartCoroutine(SpawnEnemy());
    }
    IEnumerator SpawnEnemy()
    {
        while (true)
        {
           GameObject spawnEnemy = SelectEnemy();
           Instantiate(spawnEnemy);
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
}
