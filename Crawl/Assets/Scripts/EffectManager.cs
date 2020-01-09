using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectManager : Singleton<EffectManager>
{
    GameObject player;
    [SerializeField] GameObject water_death_effect;
    [SerializeField] GameObject sky_death_effect;
    [SerializeField] GameObject space_death_effect;
    [SerializeField] GameObject freeze_effect;
    [SerializeField] GameObject fire_effect;
    GameObject freeze;
    GameObject fire;

    void Start()
    {
        player = LevelManager.Instance.GetPlayer();   
    }

    public void SpawnWaterDeath(Transform enemy)
    {
        Instantiate(water_death_effect, enemy.position, Quaternion.Euler(0, 0, 0));
    }
    public void SpawnSkyDeath(Transform enemy)
    {
        Instantiate(sky_death_effect, enemy.position, Quaternion.Euler(0, 0, 0));
    }
    public void SpawnSpaceDeath(Transform enemy)
    {
        Instantiate(space_death_effect, enemy.position, Quaternion.Euler(0, 0, 0));
    }
    public GameObject Freeze(Transform enemy)
    {
        freeze = Instantiate(freeze_effect, enemy.position, Quaternion.Euler(0, 0, 0));
        freeze.transform.parent = enemy.transform;
        return freeze;
    }
    public void DestroyFreeze()
    {
        Destroy(freeze);
    }
    public GameObject Fire(Transform enemy)
    {
        fire = Instantiate(fire_effect, enemy.position, Quaternion.Euler(0, 0, 0));
        fire.transform.parent = enemy.transform;
        return fire;
        
    }
}
