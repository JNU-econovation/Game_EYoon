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
    public GameObject window1;
    public GameObject window2;
    public GameObject window3;
    [SerializeField] int dist = 80;
    int delay = 4;
    float[] weight = {40.0f, 40.0f, 20.0f};
    float rand;
    List<GameObject> hazards = new List<GameObject>();
    public List<GameObject> windows = new List<GameObject>();

    private void Start()
    {
        hazards.Add(npc);
        hazards.Add(security);
        hazards.Add(nullObject);
        player = service.GetComponent<LevelManager>().player;
       // StartCoroutine(MakeHazard());
    }
    
    private int SelectWindow()
    {
        int rand = Random.Range(0, windows.Count-1);
        
        return rand;
    }
    public int SelectHazard(float[] weight)
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
    
    public IEnumerator MakeHazard(GameObject obj)
    {
        while (true)
        {            
            SpawnHazard(obj);
            StartCoroutine(Wait(5.0f));
        }       
    }
    
    private IEnumerator Wait(float wait)
    {
        yield return new WaitForSeconds(wait);        
    }
 
}
