using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill_Copper_SelectSilver : Skill_Copper
{
    private void Start()
    {
        variation = new float[] { 1, 2, 3 };
    }
    public override void SkillFunction()
    {
        IncreaseCount();
        skillUI.SetActive(false);
    }
}
