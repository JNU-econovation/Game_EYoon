using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snow : Weather
{
    GameObject player;
    [SerializeField] GameObject service;
    static float damage = 2;
    float delay = 1.0f;        
    
    IEnumerator Damage()
    {       
        player = service.GetComponent<LevelManager>().player;
        for (int i =0; i<5; i++)
        {
            player.GetComponent<Health>().DecreaseHP(damage);
            yield return new WaitForSeconds(delay);
        }
    }

    public void DecreaseDamage()
    {
        float level = JacketInventory.Instance.jacketLevel;
        damage = 2.0f - (0.2f * level);
    }

    public override void OnEnable()
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
    }
}
