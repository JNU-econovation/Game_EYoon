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
    GameObject spawnObject;
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
        hazards.Add(blanket);
        hazards.Add(nullObject);
        player = service.GetComponent<LevelManager>().player;

        StartCoroutine(MakeHazard());
    }

    IEnumerator MakeHazard()
    {
        yield return new WaitForSeconds(delaytime);        
        spawnObject = SpawnHazard();
        Destroy(spawnObject, 5.0f);        
        StartCoroutine(MakeHazard());
        
           
    }
    
    GameObject SelectWindow(List<GameObject> HazardSpawnWindows)
    {
        ReRand:
        int rand = Random.Range(0, HazardSpawnWindows.Count);
        if (HazardSpawnWindows[rand].transform.position.y < player.transform.position.y)
            goto ReRand;
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
        if(i != weight.Length-1)
            temp.GetComponent<Hazard>().Function(window);
        selectedRand.Clear();
        return temp;
    }
      
}
