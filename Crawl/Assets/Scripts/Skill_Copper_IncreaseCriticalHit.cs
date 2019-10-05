using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill_Copper_IncreaseCriticalHit : Skill_Copper
{
    public override void SkillFunction()
    {
        variation = new float[] { 40, 80, 120 };
        IncreaseCount();
        if (skill_Count < 3)
        {
            Player_AbilityManager.Instance.IncreaseCritical_HIt(variation[0]);
        }
        else if (skill_Count < 5)
        {
            Player_AbilityManager.Instance.IncreaseCritical_HIt(variation[1]);
        }
        else if (5 <= skill_Count)
        {
            LimitCount();
            Player_AbilityManager.Instance.IncreaseCritical_HIt(variation[2]);
        }
    }
}
