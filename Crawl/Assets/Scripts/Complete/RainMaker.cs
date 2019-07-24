using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DigitalRuby.RainMaker;

public class RainMaker : Weather
{
 
    private void Start()
    {
        gameObject.SetActive(false);
    }
   
    
    IEnumerator FadeIn()
    {
        for (int i = 1; i < 11; i++)
        {
            GetComponent<RainScript2D>().RainIntensity = i * 0.1f;
            if (i < 5)
                yield return new WaitForSeconds(0.5f);
            else if (i >= 5)
                yield return new WaitForSeconds(0.1f);


        }
        StartCoroutine(FadeOut());
    }
    IEnumerator FadeOut()
    {
        for (int i = 1; i < 10; i++)
        {
            GetComponent<RainScript2D>().RainIntensity -= 0.1f;
            if (i < 5)
                yield return new WaitForSeconds(0.1f);
            else if (i >= 5)
                yield return new WaitForSeconds(0.5f);
        }
       
        if (GetComponent<RainScript2D>().RainIntensity != 0.1f)
            GetComponent<RainScript2D>().RainIntensity = 0;
        gameObject.SetActive(false);
    }
   
        /*
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
            */
    

    public override void MakeWeather()
    {
        gameObject.SetActive(true);
        ParticleSystem[] rain = GetComponentsInChildren<ParticleSystem>();
        for (int j = 0; j < rain.Length; j++)
        {
            rain[j].Play();
        }
        StartCoroutine(FadeIn());
    }

    public override void Function()
    {
                  
    }
}
