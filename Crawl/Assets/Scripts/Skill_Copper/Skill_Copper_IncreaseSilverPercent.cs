using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill_Copper_IncreaseSilverPercent : Skill_Copper
{
    static int skill_Count = 0;
    private void Start()
    {
        skillUI = GetComponentInParent<UI_SkillUI>().gameObject;
        variation = new float[] { 15, 20, 25 };
    }
    public override void InitializeValue()
    {
        skill_Count = 0;
    }
    public override void SkillFunction()
    {
        IncreaseCount();
        float[] itemWeight = ItemManager.Instance.GetItemWeight();       
        if (skill_Count < 3)
        {
            itemWeight[1] += variation[0];
            itemWeight[0] -= variation[0];
        }else if (skill_Count < 5)
        {
            itemWeight[1] += variation[1];
            itemWeight[0] -= variation[1];
        }
        else if (5 <= skill_Count)
        {
            itemWeight[1] += variation[2];
            itemWeight[0] -= variation[2];
        }
        ItemManager.Instance.SetItemWeight(itemWeight);
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
        return "은 확률 증가";
    }
    public override string GetSkillFigure()
    {
        return "" + GetVariation() + "%";
    }
}
