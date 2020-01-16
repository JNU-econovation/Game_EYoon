using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectManager : Singleton<EffectManager>
{
    GameObject player;
    public GameObject water_death_effect;
    public GameObject sky_death_effect;
    public GameObject space_death_effect;
    public GameObject freeze_effect;
    public GameObject fire_effect;
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
        freeze_effect.SetActive(true);
        freeze = freeze_effect;
        freeze.transform.position = enemy.position;
        freeze.transform.parent = enemy.transform;
        return freeze;
    }
    public void DestroyFreeze()
    {
        Destroy(freeze);
    }
    public GameObject Fire(Transform enemy)
    {
        fire_effect.SetActive(true);
        fire = fire_effect;
        fire.transform.position = enemy.position;
        fire.transform.parent = enemy.transform;
        return fire;
        
    }
}
