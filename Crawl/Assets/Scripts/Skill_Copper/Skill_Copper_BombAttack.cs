using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill_Copper_BombAttack : Skill_Copper
{
    static int skill_Count = 0;
    Player_Bomb_Attack bomb_Attack;
    private void Start()
    {
        player = LevelManager.Instance.GetPlayer();
        skillUI = GetComponentInParent<UI_SkillUI>().gameObject;
        bomb_Attack = player.GetComponent<Player_Bomb_Attack>();
        variation = new float[] { 1, 2, 3 };
    }
    public override void SkillFunction()
    {        
        IncreaseCount();       
        if (skill_Count < 3)
        {
            bomb_Attack.ThrowBomb((int)variation[0]);
        }
        else if (skill_Count < 5)
        {
            bomb_Attack.ThrowBomb((int)variation[1]);
        }
        else if (5 <= skill_Count)
        {
            bomb_Attack.ThrowBomb((int)variation[2]);
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
        return "폭탄 공격" + "(" + GetVariation() + "회)";
    }
}
