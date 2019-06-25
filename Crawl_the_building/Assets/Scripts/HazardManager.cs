using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HazardManager : MonoBehaviour
{
    public GameObject Npc;
    public GameObject Security;
    public GameObject nothing;
    float[] weight = {1.5f, 1.5f, 97f};
    float rand;
    List<GameObject> Hazards = new List<GameObject>();

    private void Start()
    {
        Hazards.Add(Npc);
        Hazards.Add(Security);
        Hazards.Add(nothing);
    }
    public int SelectHazard(float[] weight)
    {
        rand = Random.Range(0, 100);
        float total = 0;
        Debug.Log(rand);
        for(int i = 0; i < weight.Length; i++)
        {
            total += weight[i];
            if (rand <= total)
                return i;
            Debug.Log(total);
        }
        return weight.Length - 1;
    }
    public void SpawnHazard(Vector3 vector3)
    {
        int i = SelectHazard(weight);
        Hazards[i].transform.position = vector3;
        Instantiate(Hazards[i]);
    }
}
