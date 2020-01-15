using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill_Diamond_IncreaseRubyPercent : Skill_Diamond
{
    static int skill_Count = 0;
    private void Start()
    {
        skillUI = GetComponentInParent<UI_SkillUI>().gameObject;
        variation = new float[] { 5, 7, 9 };
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
            itemWeight[4] += variation[0];
            itemWeight[3] -= variation[0];
        }
        else if (skill_Count < 5)
        {
            itemWeight[4] += variation[1];
            itemWeight[3] -= variation[1];
        }
        else
        {
            itemWeight[4] += variation[2];
            itemWeight[3] -= variation[2];
        }
        if (itemWeight[0] < 0)
        {
            itemWeight[4] += -itemWeight[0];
        }
        if (itemWeight[1] < 0)
        {
            itemWeight[4] += -itemWeight[1];
        }
        if (itemWeight[2] < 0)
        {
            itemWeight[4] += -itemWeight[2];
        }
        if(itemWeight[3] < 0)
        {
            itemWeight[4] += -itemWeight[3];
        }
        float sum = 0;
        for (int i = 0; i < 5; i++)
            sum += itemWeight[i];
        if (sum >= 100)
        {
            itemWeight[4] -= (sum - 100);
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
        return "루비 확률 증가";
    }
    public override string GetSkillFigure()
    {
        return "" + GetVariation() + "%";
    }
}
