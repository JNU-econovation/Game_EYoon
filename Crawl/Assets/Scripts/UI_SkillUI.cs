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
        LevelManager.Instance.Pause();
        ChooseSkill();
    }
    private void OnDisable()
    {
        for (int j = 0; j < skillButtons.Count; j++)
        {
            skillButtons[j].SetIsStop(false);
        }
        LevelManager.Instance.Resume();
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

