using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DigitalRuby.RainMaker;

public class RainMaker : Weather
{

    public bool isRain = false;
    private void Start()
    {
        gameObject.SetActive(false);
    }
<<<<<<< HEAD
    public void OnEnable()
    {

        StartCoroutine(DisableSelf());
    }

    IEnumerator DisableSelf()
    {
        yield return new WaitForSeconds(enableTime);
        gameObject.SetActive(false);
        isRain = false;       
=======
    
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
>>>>>>> 8752465acfa75a29e0d138e3631aa76539037f25
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
        isRain = true;            
    }
}
