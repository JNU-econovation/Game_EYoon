using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillManager : MonoBehaviour
{
    [SerializeField] float[] skillWeight;
    public int SelectSkill()
    {
        float rand = Random.Range(0, 100);
        float sum = 0;
        int i = 1;
        while (i < skillWeight.Length)
        {
            sum += skillWeight[i];
            if (rand <= sum)
            {
                return i;
            }
            i++;
        }
        return 1;
    }
}
