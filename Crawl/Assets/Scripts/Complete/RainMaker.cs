using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainMaker : Weather
{

    public bool isRain = false;
    private void Start()
    {
        gameObject.SetActive(false);
    }
    public void OnEnable()
    {

        StartCoroutine(DisableSelf());
    }

    IEnumerator DisableSelf()
    {
        yield return new WaitForSeconds(enableTime);
        gameObject.SetActive(false);
        isRain = false;       
    }

    public override void MakeWeather()
    {
        gameObject.SetActive(true);
        ParticleSystem[] rain = GetComponentsInChildren<ParticleSystem>();
        for (int j = 0; j < rain.Length; j++)
        {
            rain[j].Play();
        }
        Function();
    }

    public override void Function()
    {
        isRain = true;            
    }
}
