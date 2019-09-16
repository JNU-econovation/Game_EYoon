using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeatherManager : Singleton<WeatherManager>
{
    float rand;
    float delayTime = 9.0f;
    float enableTime = 3.0f;
    public float[] weight = { 20.0f, 30.0f, 20.0f ,10.0f};

    public List<GameObject> weather = new List<GameObject>();
    GameObject player;
    GameObject service;

    private void Start()
    {
        service = GameObject.FindGameObjectWithTag("Service");
        player = service.GetComponent<LevelManager>().player;
       
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
        //    weight = LevelManager.Instance.ChangeWeatherWeight();
            int i = SelectIndex(weight);
            weather[i].GetComponent<Weather>().MakeWeather();          
        }
    }  
}
