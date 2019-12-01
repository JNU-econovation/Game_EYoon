using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectManager : Singleton<EffectManager>
{
    [SerializeField] GameObject[] effects; // 0 = 물 타입 죽음 1 = 하늘 타임 죽음 2 = 우주 타입 죽음
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnWaterDeath(Transform enemy)
    {
        Instantiate(effects[0], enemy.position, Quaternion.Euler(0, 0, 0));
    }
    public void SpawnSkyDeath(Transform enemy)
    {
        Instantiate(effects[1], enemy.position, Quaternion.Euler(0, 0, 0));
    }
    public void SpawnSpaceDeath(Transform enemy)
    {
        Instantiate(effects[2], enemy.position, Quaternion.Euler(0, 0, 0));
    }
}
