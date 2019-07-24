using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeatherManager : Singleton<WeatherManager>
{
    float rand;
    float delayTime = 11.0f;
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
            weather[i].GetComponent<Weather>().MakeWeather();          
        }
    }  
}
