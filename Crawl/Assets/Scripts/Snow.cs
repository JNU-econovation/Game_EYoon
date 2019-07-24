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
        gameObject.SetActive(false);
        
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


    IEnumerator FadeIn()
    {
        var main = GetComponentInChildren<ParticleSystem>().main;
        for (int i = 1; i < 11; i++)
        {
            main.startColor = new Color(255, 255, 255, i * 0.1f);
            yield return new WaitForSeconds(0.2f);
        }
        for (int i = 0; i < 5; i++)
        {
            DecreaseDamage();
            player.GetComponentInChildren<PlayerEffect>().freezeEffect.SetActive(true);
            player.GetComponent<Health>().DecreaseHP(damage);
            yield return new WaitForSeconds(delay);
        }
        StartCoroutine(FadeOut());
    }
    IEnumerator FadeOut()
    {
        var main = GetComponentInChildren<ParticleSystem>().main;
        for (int i = 1; i < 11; i++)
        {
            main.startColor = new Color(255, 255, 255, 1 - i * 0.1f);
            yield return new WaitForSeconds(0.2f);
        }
        gameObject.SetActive(false);

    }
    IEnumerator DisableSelf()
    {
        yield return new WaitForSeconds(enableTime);
        StartCoroutine(FadeOut());
        gameObject.SetActive(false);

        /*
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
        }*/
           
    }

    public override void Function()
    {
        
    }

    public override void MakeWeather()
    {
        gameObject.SetActive(true);
        transform.position = player.transform.position - new Vector3(0,100,0);
        StartCoroutine(FadeIn());
        Function();
    }
}
