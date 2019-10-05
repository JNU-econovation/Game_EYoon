using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill_Copper_IncreaseAttack : Skill_Copper
{
    private void Start()
    {
        variation = new float[] { 1, 2, 3 };
    }
    public override void SkillFunction()
    {
       
        IncreaseCount();
        if (skill_Count < 3)
        {
            Player_AbilityManager.Instance.IncreaseAttack(variation[0]);
        }
        else if (skill_Count < 5)
        {
            Player_AbilityManager.Instance.IncreaseAttack(variation[1]);
        }
        else if (5 <= skill_Count)
        {
            LimitCount();
            Player_AbilityManager.Instance.IncreaseAttack(variation[2]);
        }
       // skillUI.SetActive(false);
    }


}
