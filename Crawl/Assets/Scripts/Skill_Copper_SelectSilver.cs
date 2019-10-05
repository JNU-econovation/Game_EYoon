using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill_Copper_SelectSilver : Skill_Copper
{
    public override void SkillFunction()
    {
        variation = new float[] { 10, 20, 30 };
        IncreaseCount();
       
    }
}
