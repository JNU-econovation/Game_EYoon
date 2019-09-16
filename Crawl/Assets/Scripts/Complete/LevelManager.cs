using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : Singleton<LevelManager>
{
    public GameObject playerPrefab;   
    public GameObject player;
    public GameObject[] map;
    public float height;
    public List<GameObject> fireList = new List<GameObject>();

    private void Awake()
    {
        player = Instantiate(playerPrefab);
    }
    /*
    public void RecoverWindows(GameObject obj)
    {
        Window window= obj.GetComponent<Window>();   
        window.itemMade = false;
        window.HP = window.maxHP;            
    }
    */

    public float[] ChangeWeatherWeight()
    { //가중치 순서 물건던지기, 화재, 창문열기, 이불털기, null, 경비원, 페인트공
        float height = player.transform.position.y / 10;
        /* if (0 <= height && height < 50)
         {
             float[] weight = { 50, 0, 20, 0, 30, 0, 0 };
             HazardManager.Instance.weight = weight;
         }*/
        if (0 <= height && height < 50)
        {
            float[] weight = { 100, 0, 0, 0 };
            return weight;
        }
        else if (50 <= height && height < 100)
        {
            float[] weight = { 0, 100, 0, 0 };
            return weight;
        }
        else if (100 <= height && height < 150)
        {
            float[] weight = { 0, 0, 100, 0 };
            return weight;
        }
        else if (150 <= height && height < 10)
        {
            float[] weight = { 100, 0, 0, 0 };
            return weight;
        }
        else
            return WeatherManager.Instance.weight;
     
        
    }
    public void ChangeHazardWeight()
    { //가중치 순서 물건던지기, 화재, 창문열기, 이불털기, null, 경비원, 페인트공
        float height = player.transform.position.y / 10;
        /* if (0 <= height && height < 50)
         {
             float[] weight = { 50, 0, 20, 0, 30, 0, 0 };
             HazardManager.Instance.weight = weight;
         }*/


        if (50 <= height && height < 100)
        {
            float[] weight = { 50, 0, 17, 0, 15, 0, 18 };
            HazardManager.Instance.weight = weight;
        }
        else if (100 <= height && height < 150)
        {
            float[] weight = { 45, 15, 15, 0, 10, 0, 15 };
            HazardManager.Instance.weight = weight;
        }
        else if (150 <= height && height < 250)
        {
            float[] weight = { 30, 15, 13, 15, 10, 0, 17 };
            HazardManager.Instance.weight = weight;
        }
        else if (250 <= height && height < 350)
        {
            float[] weight = { 30, 20, 10, 15, 10, 5, 10 };
            HazardManager.Instance.weight = weight;
        }
        else if (350 <= height && height < 450)
        {
            float[] weight = { 30, 20, 5, 15, 10, 10, 10 };
            HazardManager.Instance.weight = weight;
        }
        else if (450 <= height && height < 500)
        {
            float[] weight = { 30, 20, 5, 15, 10, 10, 10 };
            HazardManager.Instance.weight = weight;
        }
    }
    public float[] ChangeItemWeight()
    { //가중치 순서 물건던지기, 화재, 창문열기, 이불털기, null, 경비원, 페인트공
        float height = player.transform.position.y / 10;
        /* if (0 <= height && height < 50)
         {
             float[] weight = { 50, 0, 20, 0, 30, 0, 0 };
             HazardManager.Instance.weight = weight;
         }*/
        /*
       if (0 <= height && height < 10)
       {
           float[] weight = { 0, 100, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
           return weight;
       }
       else if (10 <= height && height < 20)
       {
           float[] weight = { 0, 0, 100, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
           return weight;
       }
       else if (20 <= height && height < 30)
       {
           float[] weight = { 0, 0, 0, 100, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
           return weight;
       }
       else if (30 <= height && height < 40)
       {
           float[] weight = { 0, 0, 0, 0, 100, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
           return weight;
       }
       else if (40 <= height && height < 50)
       {
           float[] weight = { 0, 0, 0, 0, 0, 100, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
           return weight;
       }
       else if (50 <= height && height < 60)
       {
           float[] weight = { 0, 0, 0, 0, 0, 0, 100, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
           return weight;
       }
       else if (60 <= height && height < 70)
       {
           float[] weight = { 0, 0, 0, 0, 0, 0, 0, 100, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
           return weight;
       }
       else if (70 <= height && height < 80)
       {
           float[] weight = { 0, 0, 0, 0, 0, 0, 0, 0, 100, 0, 0, 0, 0, 0, 0, 0, 0 };
           return weight;

       }
       else if (80 <= height && height < 90)
       {
           float[] weight = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 100, 0, 0, 0, 0, 0, 0, 0 };
           return weight;
       }
       else if (90 <= height && height < 100)
       {
           float[] weight = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 100, 0, 0, 0, 0, 0, 0 };
           return weight;
       }
       else if (100 <= height && height < 110)
       {
           float[] weight = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 100, 0, 0, 0, 0, 0 };
           return weight;
       }
       else if (110 <= height && height < 120)
       {
           float[] weight = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 100, 0, 0, 0, 0 };
           return weight;
       }
       else if (120 <= height && height < 130)
       {
           float[] weight = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 100, 0, 0, 0 };
           return weight;
       }
       else if (130 <= height && height < 140)
       {
           float[] weight = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 100, 0, 0 };
           return weight;
       }
       else if (140 <= height && height < 150)
       {
           float[] weight = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 100, 0 };
           return weight;
       }
       else if (150 <= height && height < 160)
       {
           float[] weight = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 100 };
           return weight;
       }
       else if (150 <= height && height < 160)
       {
           float[] weight = { 0, 100, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
           return weight;
       }
       else { }*/
        float[] weight = {0 , 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        return weight;
    }

}
