using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HazardManager : Singleton<HazardManager>
{
    public GameObject NPC;
    public GameObject fire;
    public GameObject open;
    public GameObject service;
    GameObject player;   
    float delaytime = 1.0f;
    float[] weight = {30.0f, 30.0f, 20.0f};
    float rand;
    public GameObject[] map;
    float mapHeight = 187;
    List<GameObject> hazards = new List<GameObject>();   
    List<GameObject> HazardSpawnWindows = new List<GameObject>();
    List<int> selectedRand = new List<int>();
    public Vector3 selectedWindowPosition;
    private void Start()
    {
        hazards.Add(NPC);
        hazards.Add(fire);       
        hazards.Add(open);
        player = service.GetComponent<LevelManager>().player;
        StartCoroutine(MakeHazard());
        
    }

    public IEnumerator MakeHazard()
    {
        while (true)
        {
            int spawnCount = 2;
           

            for (int i = 0; i < spawnCount; i++)
            {                
                GameObject temp = SpawnHazard();                
                Destroy(temp, 5.0f);
                
            }
            selectedRand.Clear();
            yield return new WaitForSeconds(delaytime);
        }
    }
    GameObject SelectWindow(List<GameObject> HazardSpawnWindows)
    {
        ReRand:
        int rand = Random.Range(0, HazardSpawnWindows.Count);
        if (selectedRand.Count == 0)
            selectedRand.Add(rand);
        for(int i = 0; i < selectedRand.Count; i++)
        {
            if (rand == selectedRand[i])
                goto ReRand;            
        }
        selectedRand.Add(rand);        
        return HazardSpawnWindows[rand];
    }
    GameObject SelectMap()
    {
        int i = (int)(player.transform.position.y) / (int)(mapHeight);
       
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

    public GameObject SpawnHazard()
    {
        HazardSpawnWindows = SelectMap().GetComponent<WindowList>().windows;
        GameObject window = SelectWindow(HazardSpawnWindows);
        int i = SelectHazard(weight);

        hazards[i].transform.position = window.transform.position;
        GameObject temp = Instantiate(hazards[i]);
      
        temp.GetComponent<Hazard>().Function(window);
        return temp;
    }
      
}
