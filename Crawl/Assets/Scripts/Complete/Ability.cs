using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ability : Singleton<Ability>
{
    public float armor;
    public float maxArmor = 80.0f;
    public float avoidance;
    static int jacketLevel;
    GameObject snow;
    float[] avoidWeight = new float[2];
 
    public int TakeJacketLevel()
    {
        jacketLevel++;
        return jacketLevel;
    }
    public void IncreaseArmor(float n)
    {
        armor += n;
        if(armor >= 80.0f)
        {
            armor = 80.0f;
        }
    }

    public bool IsAvoid()
    {
        int i = 0;
        avoidWeight[0] = avoidance;
        avoidWeight[1] = 100 - avoidance;
        float rand = Random.Range(0, 100);
        float total = 0;
        while(i < avoidWeight.Length)
        { 
            total += avoidWeight[i];
            if (rand <= total)
                break;
            i++;
        }
        return i == 0;
    }
}
