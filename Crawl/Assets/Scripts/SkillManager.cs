using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillManager : Singleton<SkillManager>
{
    [SerializeField] float[] skillWeight_Copper;
    [SerializeField] float[] skillWeight_Silver;
    [SerializeField] float[] skillWeight_Gold;
    [SerializeField] float[] skillWeight_Diamond;
    [SerializeField] float[] skillWeight_Ruby;
    Skill skill_Copper;
    private void Start()
    {
        
    }
    float[] SelectWeight(int n)
    {
        float[] skillWeight = { 0 };
        switch (n)
        {
            case 1:
                skillWeight = skillWeight_Copper;
                break;
            case 2:
                skillWeight = skillWeight_Silver;
                break;
            case 3:
                skillWeight = skillWeight_Gold;
                break;
            case 4:
                skillWeight = skillWeight_Diamond;
                break;
            case 5:
                skillWeight = skillWeight_Ruby;
                break;
        }
        return skillWeight;
    }
    public int SelectSkill(int n)
    {
        float[] skillWeight = SelectWeight(n);

         float rand = Random.Range(0.01f, 100);
        float sum = 0;
        int i = 0;
        while (i < skillWeight.Length)
        {
            sum += skillWeight[i];
            if (rand <= sum)
            {
                return i;
            }
            i++;
        }
        return 0;
    }
    
    public float[] GetSkillWeight_Copper()
    {       
        return skillWeight_Copper;
    }
    public void SetSkillWeight_Copper(float[] weight)
    {
        skillWeight_Copper = weight;
    }

    public float[] GetSkillWeight_Silver()
    {
        return skillWeight_Silver;
    }
    public void SetSkillWeight_Silver(float[] weight)
    {
        skillWeight_Silver = weight;
    }

    public float[] GetSkillWeight_Gold()
    {
        return skillWeight_Gold;
    }
    public void SetSkillWeight_Gold(float[] weight)
    {
        skillWeight_Gold = weight;
    }

    public float[] GetSkillWeight_Diamond()
    {
        return skillWeight_Diamond;
    }
    public void SetSkillWeight_Diamond(float[] weight)
    {
        skillWeight_Diamond = weight;
    }

    public float[] GetSkillWeight_Ruby()
    {
        return skillWeight_Ruby;
    }
    public void SetSkillWeight_Ruby(float[] weight)
    {
        skillWeight_Ruby = weight;
    }
}
