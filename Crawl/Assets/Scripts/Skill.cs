using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class Skill : MonoBehaviour
{
    protected float[] variation = new float[3];
   // protected int skill_Count = 0;
    GameObject player;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    abstract public void LimitCount();

    abstract public float GetVariation();

    abstract public void IncreaseCount();

    abstract public int GetCopperCount();
   
    
}
