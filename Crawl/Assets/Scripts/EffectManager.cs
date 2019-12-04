using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectManager : Singleton<EffectManager>
{
    GameObject player;
    [SerializeField] GameObject[] effects; // 0 = 물 타입 죽음 1 = 하늘 타임 죽음 2 = 우주 타입 죽음 3 = 얼리기 4 = 불태우기
    GameObject freeze;
    GameObject fire;
    // Start is called before the first frame update
    void Start()
    {
        player = LevelManager.Instance.GetPlayer();   
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
    public GameObject Freeze(Transform enemy)
    {
        freeze = Instantiate(effects[3], enemy.position, Quaternion.Euler(0, 0, 0));
        freeze.transform.parent = enemy.transform;
        return freeze;
    }
    public void DestroyFreeze()
    {
        Destroy(freeze);
    }
    public GameObject Fire(Transform enemy)
    {
        fire = Instantiate(effects[4], enemy.position, Quaternion.Euler(0, 0, 0));
        fire.transform.parent = enemy.transform;
        return fire;
        
    }
}
