using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill_Copper_IncreaseSilverPercent : Skill_Copper
{
    private void Start()
    {
        variation = new float[] { 1, 2, 3 };
    }
    public override void SkillFunction()
    {
        IncreaseCount();
        float[] skillWeight = SkillManager.Instance.GetSkillWeight();      
        if (skill_Count < 3)
        {
            skillWeight[1] += variation[0];
            skillWeight[0] -= variation[0];
        }else if (skill_Count < 5)
        {
            skillWeight[1] += variation[1];
            skillWeight[0] -= variation[1];
        }
        else if (5 <= skill_Count)
        {
            skillWeight[1] += variation[2];
            skillWeight[0] -= variation[2];
        }
        SkillManager.Instance.SetSkillWeight(skillWeight);
        skillUI.SetActive(false);
    }

   
}
