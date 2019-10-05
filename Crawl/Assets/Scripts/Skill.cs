using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill : MonoBehaviour
{
    protected float[] variation = new float[3];
    protected int skill_Count = 0;
    GameObject player;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    public void LimitCount()
    {      
        if (skill_Count >= 5)
        { 
            skill_Count = 5;           
        }
    }
    public float GetVariation()
    {
        if (skill_Count <= 1)
            return variation[0];
        else if (2 <= skill_Count && skill_Count <= 3)
            return variation[1];
        else
            return variation[2];
    }
    public void IncreaseCount()
    {
        skill_Count++;
    }
    public int GetCopperCount()
    {
        return skill_Count;
    }
}
