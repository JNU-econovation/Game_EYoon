using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill_Gold_Freeze : Skill_Gold
{
    static int skill_Count = 0;
    Player_Attack player_Attack;
    private void Start()
    {
        player = LevelManager.Instance.GetPlayer();
        player_Attack = player.GetComponent<Player_Attack>();
        skillUI = GetComponentInParent<UI_SkillUI>().gameObject;
        variation = new float[] { 2, 3, 5 };
    }
    public override void InitializeValue()
    {
        skill_Count = 0;
    }
    public override void SkillFunction()
    {
        IncreaseCount();
        if (skill_Count < 3)
        {
            player_Attack.OnFreeze(variation[0]);
        }
        else if (skill_Count < 5)
        {
            player_Attack.OnFreeze(variation[1]);
        }
        else if (5 <= skill_Count)
        {
            player_Attack.OnFreeze(variation[2]);
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
        return "적 얼리기";
    }
    public override string GetSkillFigure()
    {
        return "" + GetVariation() + "초";
    }
}
