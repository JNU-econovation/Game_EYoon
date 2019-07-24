using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snow : Weather
{
    GameObject player;
    [SerializeField] GameObject service;
    static float damage = 2;
    float minDamage = 0.5f;
    float delay = 1.0f;

    private void Start()
    {
        player = service.GetComponent<LevelManager>().player;
        
    }
    private void Update()
    {
        transform.position = player.transform.position - new Vector3(0, 200, 0);
    }

    IEnumerator Damage()
    {              
        for (int i =0; i<5; i++)
        {
            DecreaseDamage();
            player.GetComponent<Health>().DecreaseHP(damage);
            yield return new WaitForSeconds(delay);
        }
    }
    
    public void DecreaseDamage()
    {
        int level = player.GetComponent<Ability>().TakeJacketLevel();
        damage -= (0.1f * level);
        if (damage <= minDamage)
            damage = minDamage;
    }



    IEnumerator DisableSelf()
    {
        var main = GetComponentInChildren<ParticleSystem>().main;
        for (int i = 1; i < 11; i++)
        {
            main.startColor = new Color(255, 255, 255, i * 0.1f);
            yield return new WaitForSeconds(0.2f);
        }
      
        for (int i = 1; i < 11; i++)
        {
            main.startColor = new Color(255,255,255,1 - i * 0.1f);
            yield return new WaitForSeconds(0.2f);
        }
           
    }

    public override void Function()
    {
        StartCoroutine(Damage());
    }

    public override void MakeWeather()
    {
        
        StartCoroutine(DisableSelf());
        Function();
    }
}
