using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_SkillUI : MonoBehaviour
{
    List<UI_SkillButton> skillButtons = new List<UI_SkillButton>();
    [SerializeField] int jewerlyNum;
    private void Awake()
    {
        UI_SkillButton[] buttons = GetComponentsInChildren<UI_SkillButton>();
        foreach (var button in buttons)
        {
            skillButtons.Add(button);
        }
   
    }
    private void OnEnable()
    {
       
        StartCoroutine(Wait(0.5f));
    }
    private void OnDisable()
    {
        for (int j = 0; j < skillButtons.Count; j++)
        {
            skillButtons[j].SetIsStop(false);
        }
    }
    void ChooseSkill()
    {
        for (int j = 0; j < skillButtons.Count; j++)
        {
            skillButtons[j].SetSkillNum(SkillManager.Instance.SelectSkill(jewerlyNum));
            skillButtons[j].SetisSkillChosen(true);
        }
        
    }
    IEnumerator Wait(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        ChooseSkill();
    }
}

