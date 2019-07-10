using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HazardManager : Singleton<HazardManager>
{
    public GameObject NPC;
    public GameObject fire;
    public GameObject open;   
    GameObject player;   
    float delaytime = 1.0f;
    float lifeTime = 5.0f;
    public GameObject blanket;
    public GameObject nullObject;
    public GameObject security;
    public GameObject skyscraperCleaner;
    public GameObject service;  
    //가중치 순서 물건던지기, 화재, 창문열기, 이불털기, null, 경비원, 페인트공
    float[] weight = {20.0f, 10.0f, 5.0f, 10.0f, 40.0f, 5.0f, 10.0f};
    float rand;
    public GameObject[] map;
    GameObject nextMap;
    GameObject spawnObject;
    public List<GameObject> hazards = new List<GameObject>();   
    List<GameObject> windows = new List<GameObject>();
    public List<GameObject> HigherThanPlayerWins = new List<GameObject>();
    private void Start()
    {
        player = service.GetComponent<LevelManager>().player;
        StartCoroutine(MakeHazard());

    }

    private void Awake()
    {
        hazards.Add(NPC);
        hazards.Add(fire);
        hazards.Add(open);
        hazards.Add(blanket);
        hazards.Add(nullObject);
        hazards.Add(security);
        hazards.Add(skyscraperCleaner);
    }
    IEnumerator MakeHazard()
    {
        while (true)
        {
            yield return new WaitForSeconds(delaytime);
            for (int i = 0; i < 1; i++)
                StartCoroutine(DisableHazard(SpawnHazard(), lifeTime));
        }
                        
    }
    private IEnumerator DisableHazard(GameObject hazard, float lifeTime)
    {
        yield return new WaitForSeconds(lifeTime);
        Destroy(hazard);
    }
    GameObject SelectWindow(List<GameObject> windows, GameObject nextMap) 
    {
        List<GameObject> nextWindows = nextMap.GetComponent<WindowList>().windows;
        foreach (var obj in windows)        
            if (obj.transform.position.y > player.transform.position.y)
                HigherThanPlayerWins.Add(obj);

        switch (HigherThanPlayerWins.Count)
        {
            case 0:
                for (int i = 0; i < 27; i++)
                    HigherThanPlayerWins.Add(nextWindows[i]);
                break;
            case 3:
                for (int i = 0; i < 24; i++)
                    HigherThanPlayerWins.Add(nextWindows[i]);
                break;
            case 6:
                for (int i = 0; i < 21; i++)
                    HigherThanPlayerWins.Add(nextWindows[i]);
                break;
            case 9:
                for (int i = 0; i < 18; i++)
                    HigherThanPlayerWins.Add(nextWindows[i]);
                break;
            case 12:
                for (int i = 0; i < 15; i++)
                    HigherThanPlayerWins.Add(nextWindows[i]);
                break;
            case 15:
                for (int i = 0; i < 12; i++)
                    HigherThanPlayerWins.Add(nextWindows[i]);
                break;
            case 18:
                for (int i = 0; i < 9; i++)
                    HigherThanPlayerWins.Add(nextWindows[i]);
                break;
            case 21:
                for (int i = 0; i < 6; i++)
                    HigherThanPlayerWins.Add(nextWindows[i]);
                break;
            case 24:
                for (int i = 0; i < 3; i++)
                    HigherThanPlayerWins.Add(nextWindows[i]);
                break;            
           
        }

        int rand = Random.Range(0, HigherThanPlayerWins.Count);
        return HigherThanPlayerWins[rand];
    }

    GameObject SelectMap()
    {
        nextMap = player.GetComponent<PlayerMove>().nextMap;
        return player.GetComponent<PlayerMove>().playerNearMap;
    }

    int SelectHazard(float[] weight)
    {
        rand = Random.Range(0, 100);
        float total = 0;      
        for(int i = 0; i < weight.Length; i++)
        {
            total += weight[i];
            if (rand <= total)
                return i;         
        }
        return weight.Length - 1;
    }

    public GameObject SpawnHazard()
    {
        float[] randomX = { 335.0f, 360.0f, 385.0f };
        windows = SelectMap().GetComponent<WindowList>().windows;
        GameObject window = SelectWindow(windows, nextMap);
        HigherThanPlayerWins.Clear();
        int i = SelectHazard(weight);
        GameObject temp = Instantiate(hazards[i]);
        if (i == 5)
        {
            temp.transform.position = new Vector3(0, 0, 0);
        }
        else if (i == 6)
        {
            temp.transform.position = new Vector3(randomX[Random.Range(0,2)], player.transform.position.y + 187, 0);
        }
        else
        {
            temp.transform.position = window.transform.position;
        }                
        temp.GetComponent<Hazard>().Function(window);
        return temp;
    }
      
}
