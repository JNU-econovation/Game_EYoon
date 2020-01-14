using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill_Diamond_SelectRuby : Skill_Diamond
{
    static int skill_Count = 0;
    public GameObject skillUI_Ruby;
    private void Start()
    {
        skillUI = GetComponentInParent<UI_SkillUI>().gameObject;
        variation = new float[] { 2, 3, 4 };
    }
    public override void SkillFunction()
    {
        IncreaseCount();
        skillUI.SetActive(false);
        skillUI_Ruby.SetActive(true);
        
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
        return "루비 뽑기 1회";
    }
    public override string GetSkillFigure()
    {
        return "";
    }
}
