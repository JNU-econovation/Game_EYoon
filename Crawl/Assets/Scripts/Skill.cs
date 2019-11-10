using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class Skill : MonoBehaviour
{
    protected float[] variation = new float[3];
    protected string skillText;
    // protected int skill_Count = 0;
    GameObject player;
    private void Start()
    {     
        player = LevelManager.Instance.GetPlayer();
    }

    abstract public void LimitCount();

    abstract public float GetVariation();

    abstract public void IncreaseCount();

    abstract public int GetCount();

    abstract public void SkillFunction();

    abstract public string GetSkillText();
}
