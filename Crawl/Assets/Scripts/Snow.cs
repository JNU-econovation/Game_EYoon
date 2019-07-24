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
    private void Awake()
    {
        player = service.GetComponent<LevelManager>().player;
    }

    IEnumerator Damage()
    {              
        for (int i =0; i<5; i++)
        {
            DecreaseDamage();
            player.GetComponentInChildren<PlayerEffect>().freezeEffect.SetActive(true);
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

    public void OnEnable()
    {
        transform.position = Camera.main.transform.position + new Vector3(0, 50, 0);
        StartCoroutine(DisableSelf());
    }

    IEnumerator DisableSelf()
    {
        yield return new WaitForSeconds(enableTime);
        gameObject.SetActive(false);      
    }

    public override void Function()
    {
        StartCoroutine(Damage());
    }

    public override void MakeWeather()
    {
        gameObject.SetActive(true);
        Function();
    }
}
