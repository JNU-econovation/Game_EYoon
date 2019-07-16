using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeatherManager : Singleton<WeatherManager>
{
    float rand;
    float delayTime = 7.0f;
    float enableTime = 3.0f;
<<<<<<< HEAD
    float[] weight = { 33.0f, 34.0f,33.0f };
=======
    float[] weight = { 0.0f, 0.0f, 0.0f ,100.0f};
>>>>>>> 7593e985e5c6d16b086d721f29409bd37404b10d
    List<GameObject> weather = new List<GameObject>();
    GameObject player;
    public GameObject service;
    public GameObject rain;
    public GameObject nullObject;
    public GameObject snow;
    public GameObject lightningMaker;

    private void Start()
    {
        player = service.GetComponent<LevelManager>().player;
        rain = service.GetComponent<LevelManager>().rainMaker;
        weather.Add(rain);
        weather.Add(nullObject);
        weather.Add(snow);
        weather.Add(lightningMaker);
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
            else if ( i == 2)
            {
                temp.SetActive(true);
                temp.GetComponent<Snow>().SnowEffect();
                StartCoroutine(DisableSnow(temp, enableTime));
            }
            else if (i == 3)
            {
                for(int j =0; j<Random.Range(1,3); j++)
                {
                    Instantiate(lightningMaker);
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
