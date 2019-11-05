using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill_Silver_IncreaseGoldPercentage : Skill_Silver
{
    static int skill_Count = 0;
    private void Start()
    {
        skillUI = GetComponentInParent<UI_SkillUI>().gameObject;
        variation = new float[] { 1, 2, 3 };
    }
    public override void SkillFunction()
    {
        IncreaseCount();
        float[] skillWeight = SkillManager.Instance.GetSkillWeight();
        if (skill_Count < 3)
        {
            skillWeight[2] += variation[0];
            skillWeight[1] -= variation[0];
        }
        else if (skill_Count < 5)
        {
            skillWeight[2] += variation[1];
            skillWeight[1] -= variation[1];
        }
        else if (5 <= skill_Count)
        {
            skillWeight[2] += variation[2];
            skillWeight[1] -= variation[2];
        }
        SkillManager.Instance.SetSkillWeight(skillWeight);
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
    public override int GetCount()
    {
        return skill_Count;
    }
  
}
