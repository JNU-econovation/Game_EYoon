using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeatherManager : Singleton<WeatherManager>
{
    float rand;
    float delayTime = 7.0f;
    float enableTime = 3.0f;
    public float[] weight = { 20.0f, 30.0f, 20.0f ,10.0f};

    List<GameObject> weather = new List<GameObject>();
    GameObject player;
    public GameObject service;
    public GameObject rain;
    public GameObject snow;
    public GameObject lightning;
    public GameObject nullObject;
    private void Start()
    {
        player = service.GetComponent<LevelManager>().player;
        rain = service.GetComponent<LevelManager>().rainMaker;
        weather.Add(rain);
        weather.Add(snow);
        weather.Add(lightning);
        weather.Add(nullObject);
        StartCoroutine(ChangeWeather());
                            
    }
    
    int SelectIndex(float[] weight)
    {
        rand = Random.Range(0, 100);
        float total = 0;
        
        for (int i = 0; i < weight.Length; i++)
        {
            total += weight[i];
            if (rand <= total)
                return i;
        }
        return weight.Length - 1;
    }

    
    IEnumerator ChangeWeather()
    {
        
        while (true)
        {
            yield return new WaitForSeconds(delayTime);
            int i = SelectIndex(weight);
            GameObject temp = weather[i];
            
            if (i == 0)
            {
                temp.SetActive(true);
                temp.GetComponent<RainMaker>().SpeedUpDecreasingStamina();
                ParticleSystem[] rain = temp.GetComponentsInChildren<ParticleSystem>();
                for (int j = 0; j < rain.Length; j++)
                {
                    rain[j].Play();
                }
                
                StartCoroutine(DisableRain(temp, enableTime));
            }
            else if ( i == 1)
            {
                temp.SetActive(true);
                temp.GetComponent<Snow>().SnowEffect();
                StartCoroutine(DisableSnow(temp, enableTime));
            }
            else if (i == 2)
            {
                for(int j =0; j<Random.Range(1,3); j++)
                {
                    Instantiate(lightning);
                }
            }
           
        }
    }

   

    private IEnumerator DisableRain(GameObject weather, float enableTime)
    {
        yield return new WaitForSeconds(enableTime);
        weather.SetActive(false);
        weather.GetComponent<RainMaker>().RecoverStaminaSpeed();
    }
    IEnumerator DisableSnow(GameObject weather, float enableTime)
    {
        yield return new WaitForSeconds(enableTime);
        weather.SetActive(false);
        
    }

}
