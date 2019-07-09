using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeatherManager : MonoBehaviour
{
    float rand;
    float delayTime = 7.0f;
    float enableTime = 3.0f;
    float[] weight = { 100.0f, 0.0f };
    List<GameObject> weather = new List<GameObject>();
    GameObject player;
    public GameObject service;
    public GameObject rain;
    public GameObject nullObject;

    private void Start()
    {
        player = service.GetComponent<LevelManager>().player;

        weather.Add(rain);
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
            GameObject temp = Instantiate(weather[i]);
            StartCoroutine(Destroy(temp, enableTime));
        }
    }

   

    private IEnumerator Destroy(GameObject weather, float enableTime)
    {
        yield return new WaitForSeconds(enableTime);
        Destroy(weather);
    }
}
