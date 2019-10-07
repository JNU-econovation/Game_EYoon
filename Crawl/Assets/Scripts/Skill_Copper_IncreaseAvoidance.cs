using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill_Copper_IncreaseAvoidance : Skill_Copper
{
    static int skill_Count = 0;
    private void Start()
    {
        variation = new float[] { 1, 2, 3 };
    }
    public override void SkillFunction()
    {
       
        IncreaseCount();
        if (skill_Count < 3)
        {
            Player_AbilityManager.Instance.increaseAvoidance(variation[0]);
        }
        else if (skill_Count < 5)
        {
            Player_AbilityManager.Instance.increaseAvoidance(variation[1]);
        }
        else if (5 <= skill_Count)
        {
            LimitCount();
            Player_AbilityManager.Instance.increaseAvoidance(variation[2]);
        }
        skillUI.SetActive(false);
    }
    public override void LimitCount()
    {
        if (skill_Count >= 5)
        {
            skill_Count = 5;
        }
    }
    public override float GetVariation()
    {
        if (skill_Count <= 1)
            return variation[0];
        else if (2 <= skill_Count && skill_Count <= 3)
            return variation[1];
        else
            return variation[2];
    }
    public override void IncreaseCount()
    {
        skill_Count++;
    }
    public override int GetCopperCount()
    {
        return skill_Count;
    }
}
