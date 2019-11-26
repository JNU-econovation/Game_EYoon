using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill_Gold_LimitGoldCount : Skill_Gold
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
        if (skill_Count < 3)
        {
            ItemManager.Instance.item_Gold.DecreaseMaxCount((int)variation[0]);
        }
        else if (skill_Count < 5)
        {
            ItemManager.Instance.item_Gold.DecreaseMaxCount((int)variation[1]);
        }
        else if (5 <= skill_Count)
        {
            ItemManager.Instance.item_Gold.DecreaseMaxCount((int)variation[2]);
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
        return "금 제한 개수 하락" + "(" + GetVariation() + ")";
    }
}
