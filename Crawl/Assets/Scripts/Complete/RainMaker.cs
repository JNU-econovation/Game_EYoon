using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DigitalRuby.RainMaker;

public class RainMaker : Weather
{
    GameObject player;
    static float maxSpeed = 6.0f;
    float minSpeed = 1.0f;

    public void RecoverStaminaSpeed()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        player.GetComponent<Health>().staminaDecreaseSpeed = player.GetComponent<Health>().originalStaminaDecreaseSpeed;
        
    }
    
    IEnumerator DisableSelf()
    {
        for (int i = 1; i < 11; i++)
        {
            GetComponent<RainScript2D>().RainIntensity = i * 0.1f;
            if (i < 5)
               yield return new WaitForSeconds(0.5f);
           else if (i >= 5)
                yield return new WaitForSeconds(0.1f);


        }
       
        
        for (int i = 1; i < 10; i++)
        {
            GetComponent<RainScript2D>().RainIntensity -= 0.1f;
            if (i < 5)
                yield return new WaitForSeconds(0.1f);
            else if (i >= 5)
                yield return new WaitForSeconds(0.5f);
        }
        if(GetComponent<RainScript2D>().RainIntensity != 0.1f)
            GetComponent<RainScript2D>().RainIntensity = 0;
      

        RecoverStaminaSpeed();
    }

    public override void MakeWeather()
    {
        StartCoroutine(DisableSelf());
        ParticleSystem[] rain = GetComponentsInChildren<ParticleSystem>();
        for (int j = 0; j < rain.Length; j++)
        {
            rain[j].Play();
        }
        Function();
    }

    public override void Function()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        player.GetComponent<Health>().staminaDecreaseSpeed = player.GetComponent<Health>().maxStaminaDecreaseSpeed;
    }
}
