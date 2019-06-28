using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HazardManager : MonoBehaviour
{
    public GameObject npc;
    public GameObject security;
    public GameObject nothing;
    float[] weight = {1.5f, 1.5f, 97.0f};
    float rand;
    List<GameObject> hazards = new List<GameObject>();

    private void Start()
    {
        hazards.Add(npc);
        hazards.Add(security);
        hazards.Add(nothing);
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
    public void SpawnHazard(Vector3 vector3)
    {
        int i = SelectHazard(weight);
        hazards[i].transform.position = vector3;
        Instantiate(hazards[i]);
    }
}
