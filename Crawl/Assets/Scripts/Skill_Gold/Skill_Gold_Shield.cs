using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill_Gold_Shield : Skill_Gold
{
    static int skill_Count = 0;
    Player_Shield player_Shield;
    private void Start()
    {
        player = LevelManager.Instance.GetPlayer();
        player_Shield = player.GetComponent<Player_Shield>();
        skillUI = GetComponentInParent<UI_SkillUI>().gameObject;
        variation = new float[] { 1, 2, 3 };
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
            player_Shield.SetShieldCount((int)variation[0]);
        }
        else if (skill_Count < 5)
        {
            player_Shield.SetShieldCount((int)variation[1]);
        }
        else if (5 <= skill_Count)
        {
            player_Shield.SetShieldCount((int)variation[2]);
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
        return "보호막";
    }
    public override string GetSkillFigure()
    {
        return "" + GetVariation() + "회";
    }
}
