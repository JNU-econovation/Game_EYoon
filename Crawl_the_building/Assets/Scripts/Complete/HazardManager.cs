using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HazardManager : Singleton<HazardManager>
{
    public GameObject npc;
    public GameObject security;
    public GameObject nullObject;
    public GameObject service;
    GameObject player;   
    float delaytime = 4.0f;
    float[] weight = {40.0f, 40.0f, 20.0f};
    float rand;
    public GameObject[] map;
    float mapHeight;
    List<GameObject> hazards = new List<GameObject>();   
    List<GameObject> HazardSpawnWindows = new List<GameObject>();
    

    private void Start()
    {
        hazards.Add(npc);
        hazards.Add(security);
        hazards.Add(nullObject);
        player = service.GetComponent<LevelManager>().player;
        StartCoroutine(MakeHazard());
        
    }
    
    GameObject SelectWindow(List<GameObject> HazardSpawnWindows)
    {
        int rand = Random.Range(0, HazardSpawnWindows.Count);      
        return HazardSpawnWindows[rand];
    }
    GameObject SelectMap()
    {
        float i = player.transform.position.y / mapHeight;
        if (i % 3 == 0)
            return map[0];
        else if (i % 3 == 1)
            return map[1];
        else
            return map[2];
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

    public void SpawnHazard(GameObject obj)
    {
        int i = SelectHazard(weight);
        hazards[i].transform.position = obj.transform.position;
        Instantiate(hazards[i]);
    }
    
    public IEnumerator MakeHazard()
    {
        while (true)
        {
            HazardSpawnWindows = SelectMap().GetComponent<WindowList>().windows;           
            GameObject temp = SelectWindow(HazardSpawnWindows);
            SpawnHazard(temp);
            yield return new WaitForSeconds(delaytime);
        }       
    }     
}
