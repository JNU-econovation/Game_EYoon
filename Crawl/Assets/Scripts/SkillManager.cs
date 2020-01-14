using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillManager : Singleton<SkillManager>
{
    [SerializeField] float[] skillWeight_Copper;
    [SerializeField] float[] skillWeight_Silver;
    [SerializeField] float[] skillWeight_Gold;
    [SerializeField] float[] skillWeight_Diamond;
    [SerializeField] float[] skillWeight_Ruby;
    public Skill_Copper[] skill_Coppers;
    public Skill_Silver[] skill_Silvers;
    public Skill_Gold[] skill_Golds;
    public Skill_Diamond[] skill_Diamonds;
    public Skill_Ruby[] skill_Rubies;
 
    float[] SelectWeight(int n)
    {
        float[] skillWeight = { 0 };
        switch (n)
        {
            case 1:
                skillWeight = skillWeight_Copper;
                break;
            case 2:
                skillWeight = skillWeight_Silver;
                break;
            case 3:
                skillWeight = skillWeight_Gold;
                break;
            case 4:
                skillWeight = skillWeight_Diamond;
                break;
            case 5:
                skillWeight = skillWeight_Ruby;
                break;
        }
        return skillWeight;
    }
    public int SelectSkill(int n)
    {
        float[] skillWeight = SelectWeight(n);

         float rand = Random.Range(0.01f, 100);
        float sum = 0;
        int i = 0;
        while (i < skillWeight.Length)
        {
            sum += skillWeight[i];
            if (rand <= sum)
            {
                return i;
            }
            i++;
        }
        return 0;
    }
    
    public float[] GetSkillWeight_Copper()
    {       
        return skillWeight_Copper;
    }
    public void SetSkillWeight_Copper(float[] weight)
    {
        skillWeight_Copper = weight;
    }

    public float[] GetSkillWeight_Silver()
    {
        return skillWeight_Silver;
    }
    public void SetSkillWeight_Silver(float[] weight)
    {
        skillWeight_Silver = weight;
    }

    public float[] GetSkillWeight_Gold()
    {
        return skillWeight_Gold;
    }
    public void SetSkillWeight_Gold(float[] weight)
    {
        skillWeight_Gold = weight;
    }

    public float[] GetSkillWeight_Diamond()
    {
        return skillWeight_Diamond;
    }
    public void SetSkillWeight_Diamond(float[] weight)
    {
        skillWeight_Diamond = weight;
    }

    public float[] GetSkillWeight_Ruby()
    {
        return skillWeight_Ruby;
    }
    public void SetSkillWeight_Ruby(float[] weight)
    {
        skillWeight_Ruby = weight;
    }
    
    public void InitializeValue()
    {
        for (int i = 0; i < skill_Coppers.Length; i++)
            skill_Coppers[i].InitializeValue();
        for (int i = 0; i < skill_Silvers.Length; i++)
            skill_Silvers[i].InitializeValue();
        for (int i = 0; i < skill_Golds.Length; i++)
            skill_Golds[i].InitializeValue();
        for (int i = 0; i < skill_Diamonds.Length; i++)
            skill_Diamonds[i].InitializeValue();
        for (int i = 0; i < skill_Rubies.Length; i++)
            skill_Rubies[i].InitializeValue();
    }
}
/*  private void Start()
   {
       skill_Coppers[0] = FindObjectOfType<Skill_Copper_BombAttack>();
       skill_Coppers[1] = FindObjectOfType<Skill_Copper_Booster>();
       skill_Coppers[2] = FindObjectOfType<Skill_Copper_IncreaseAttack>();
       skill_Coppers[3] = FindObjectOfType<Skill_Copper_IncreaseCriticalHit>();
       skill_Coppers[4] = FindObjectOfType<Skill_Copper_IncreaseCriticalPercent>();
       skill_Coppers[5] = FindObjectOfType<Skill_Copper_IncreaseDefense>();
       skill_Coppers[6] = FindObjectOfType<Skill_Copper_IncreaseHP>();
       skill_Coppers[7] = FindObjectOfType<Skill_Copper_IncreaseReflectDamage>();
       skill_Coppers[8] = FindObjectOfType<Skill_Copper_IncreaseSilverPercent>();
       skill_Coppers[9] = FindObjectOfType<Skill_Copper_IncreaseStamina>();
       skill_Coppers[10] = FindObjectOfType<Skill_Copper_LimitCopperCount>();
       skill_Coppers[11] = FindObjectOfType<Skill_Copper_SelectSilver>();

       skill_Silvers[0] = FindObjectOfType<Skill_Silver_DecreaseMoveSpeed>();
       skill_Silvers[1] = FindObjectOfType<Skill_Silver_IncreaseAttackRange>();
       skill_Silvers[2] = FindObjectOfType<Skill_Silver_IncreaseAttackSpeed>();
       skill_Silvers[3] = FindObjectOfType<Skill_Silver_IncreaseAvoidance>();
       skill_Silvers[4] = FindObjectOfType<Skill_Silver_IncreaseGoldPercentage>();
       skill_Silvers[5] = FindObjectOfType<Skill_Silver_IncreaseLifeDrain>();
       skill_Silvers[6] = FindObjectOfType<Skill_Silver_IncreaseMaxHP>();
       skill_Silvers[7] = FindObjectOfType<Skill_Silver_IncreaseMaxStamina>();
       skill_Silvers[8] = FindObjectOfType<Skill_Silver_LimitSilverCount>();
       skill_Silvers[9] = FindObjectOfType<Skill_Silver_Magnet>();
       skill_Silvers[10] = FindObjectOfType<Skill_Silver_SelectGold>();

       skill_Golds[0] = FindObjectOfType<Skill_Gold_DoubleHP>();
       skill_Golds[1] = FindObjectOfType<Skill_Gold_DoubleStamina>();
       skill_Golds[2] = FindObjectOfType<Skill_Gold_Fire>();
       skill_Golds[3] = FindObjectOfType<Skill_Gold_Freeze>();
       skill_Golds[4] = FindObjectOfType<Skill_Gold_IncreaseAttack>();
       skill_Golds[5] = FindObjectOfType<Skill_Gold_IncreaseDefense>();
       skill_Golds[6] = FindObjectOfType<Skill_Gold_IncreaseDiaPercent>();
       skill_Golds[7] = FindObjectOfType<Skill_Gold_LimitGoldCount>();
       skill_Golds[8] = FindObjectOfType<Skill_Gold_SelectDiamond>();
       skill_Golds[9] = FindObjectOfType<Skill_Gold_Shield>();

       skill_Diamonds[0] = FindObjectOfType<Skill_Diamond_Critical>();
       skill_Diamonds[1] = FindObjectOfType<Skill_Diamond_DoubleJewerly>();
       skill_Diamonds[2] = FindObjectOfType<Skill_Diamond_IncreaseRubyPercent>();
       skill_Diamonds[3] = FindObjectOfType<Skill_Diamond_IncreaseTargetNum>();
       skill_Diamonds[4] = FindObjectOfType<Skill_Diamond_InitializeMoveSpeed>();
       skill_Diamonds[5] = FindObjectOfType<Skill_Diamond_Invincibility>();
       skill_Diamonds[6] = FindObjectOfType<Skill_Diamond_LimitDiaCount>();
       skill_Diamonds[7] = FindObjectOfType<Skill_Diamond_SelectRuby>();

       skill_Rubies[0] = FindObjectOfType<Skill_Ruby_FullHP>();
       skill_Rubies[1] = FindObjectOfType<Skill_Ruby_FullStamina>();
       skill_Rubies[2] = FindObjectOfType<Skill_Ruby_IncreaseRebirthHP>();
       skill_Rubies[3] = FindObjectOfType<Skill_Ruby_Pet>();
       skill_Rubies[4] = FindObjectOfType<Skill_Ruby_Rebirth>();
       skill_Rubies[5] = FindObjectOfType<Skill_Ruby_WeakEnemy>();
   }
   */
