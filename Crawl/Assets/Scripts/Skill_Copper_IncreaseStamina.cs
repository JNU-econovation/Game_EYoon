﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill_Copper_IncreaseStamina : Skill_Copper
{
    public override void SkillFunction()
    {
        variation = new float[] { 10, 20, 30 };
        IncreaseCount();
        if (skill_Count < 3)
        {
            Player_AbilityManager.Instance.IncreaseStamina(variation[0]);
        }
        else if (skill_Count < 5)
        {
            Player_AbilityManager.Instance.IncreaseStamina(variation[1]);
        }
        else if (5 <= skill_Count)
        {
            LimitCount();
            Player_AbilityManager.Instance.IncreaseStamina(variation[2]);
        }
    }
}
