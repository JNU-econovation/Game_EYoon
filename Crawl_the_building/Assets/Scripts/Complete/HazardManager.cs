using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HazardManager : Singleton<HazardManager>
{
    public GameObject NPC;
    public GameObject fire;
    public GameObject open;
<<<<<<< HEAD
  //  public GameObject 
    public GameObject service;
    GameObject player;   
    float delaytime = 1.0f;
    float[] weight = {100f, 50.0f, 0f};
=======
    public GameObject blanket;
    public GameObject nullObject;
    public GameObject service;
    GameObject player;   
    float delaytime = 1.0f;
    //가중치 순서 물건던지기, 화재, 창문열기, 이불털기, null
    float[] weight = {30.0f, 20.0f, 10.0f, 20.0f, 20.0f};
>>>>>>> f5c9706fb55b34f35b86866617716a4fc4350210
    float rand;
    public GameObject[] map;
    GameObject nextMap;
    GameObject spawnObject;
    List<GameObject> hazards = new List<GameObject>();   
    List<GameObject> windows = new List<GameObject>();
    public List<GameObject> HigherThanPlayerWins = new List<GameObject>();
    private void Start()
    {
        hazards.Add(NPC);
        hazards.Add(fire);       
        hazards.Add(open);
        hazards.Add(blanket);
        hazards.Add(nullObject);
        player = service.GetComponent<LevelManager>().player;
        StartCoroutine(MakeHazard());
    }
      

    IEnumerator MakeHazard()
    {
        while (true)
        {
            yield return new WaitForSeconds(delaytime);
            for(int i=0;i<1;i++)
            SpawnHazard();
        }
                        
    }
    IEnumerator WaitHalfSecond()
    {
        yield return new WaitForSeconds(0.5f);
    }
    GameObject SelectWindow(List<GameObject> windows, GameObject nextMap) 
    {
        List<GameObject> nextWindows = nextMap.GetComponent<WindowList>().windows;
        foreach (var obj in windows)        
            if (obj.transform.position.y > player.transform.position.y)
                HigherThanPlayerWins.Add(obj);

        switch (HigherThanPlayerWins.Count)
        {
            case 0: case 3:
                for(int i=0;i<24;i++)
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
        print(HigherThanPlayerWins.Count);
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
    
    public void SpawnHazard()
    {       
        windows = SelectMap().GetComponent<WindowList>().windows;        
        GameObject window = SelectWindow(windows,nextMap);
        HigherThanPlayerWins.Clear();
        int i = SelectHazard(weight);      
        hazards[i].transform.position = window.transform.position;     
        GameObject temp = Instantiate(hazards[i]);
        if(i != weight.Length-1)
            temp.GetComponent<Hazard>().Function(window);              
    }
      
}
