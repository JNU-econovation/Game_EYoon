using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill_Gold_IncreaseDefense : Skill_Gold
{
    static int skill_Count = 0;
    private void Start()
    {
        skillUI = GetComponentInParent<UI_SkillUI>().gameObject;
        variation = new float[] { 10, 20, 30 };
    }
    public override void SkillFunction()
    {
        IncreaseCount();
        if (skill_Count < 3)
        {
            float defense = Player_AbilityManager.Instance.GetDefense();
            float increase = defense * (variation[0] / 100.0f);
            Player_AbilityManager.Instance.IncreaseDefense(increase);
        }
        else if (skill_Count < 5)
        {
            float defense = Player_AbilityManager.Instance.GetDefense();
            float increase = defense * (variation[1] / 100.0f);
            Player_AbilityManager.Instance.IncreaseDefense(increase);
        }
        else if (5 <= skill_Count)
        {
            float defense = Player_AbilityManager.Instance.GetDefense();
            float increase = defense * (variation[2] / 100.0f);
            Player_AbilityManager.Instance.IncreaseDefense(increase);
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
    public override int GetCount()
    {
        return skill_Count;
    }
    public override string GetSkillText()
    {
        return "방어력 증가";
    }
    public override string GetSkillFigure()
    {
        return "현재 " + GetVariation() + "%";
    }
}
