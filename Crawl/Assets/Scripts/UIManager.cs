using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIManager : Singleton<UIManager>
{
  
    public Text[] jewerlyCountText;
    public GameObject skillUI;
    List<UI_SkillButton> skillButtons = new List<UI_SkillButton>();    
    int[] count = new int[5];
    bool onSkill;
    Item[] item = new Item[5];
    SkillManager skillManager;
    void Start()
    {
        item[0] = new Item_Copper();
        item[1] = new Item_Silver();
        item[2] = new Item_Gold();
        item[3] = new Item_Diamond();
        item[4] = new Item_Ruby();
        skillManager = GetComponent<SkillManager>();
        UI_SkillButton[] buttons = skillUI.GetComponentsInChildren<UI_SkillButton>();
        foreach (var button in buttons)
        {
            skillButtons.Add(button);
        }
        StartCoroutine(OnSkillUI());
    }
    IEnumerator OnSkillUI()
    {
        while (true)
        {
            for(int i = 0; i < 5; i++)
            {
                if(count[i] == 10)
                {
                    skillUI.gameObject.SetActive(true);
                    yield return new WaitForSeconds(1.0f);
                    ChooseSkill();
                    item[i].ResetCount();
                    ResetCount(0);
                }
               
            }
            yield return null;
        }
    }

    void ChooseSkill()
    {       
        for (int j = 0; j < skillButtons.Count; j++)
        {
           
            skillButtons[j].SetSkillNum(skillManager.SelectSkill());            
        }          
    }
    void ResetCount(int i)
    {
        count[i] = 0;
    }
    private void Update()
    {
        for(int i = 0; i < count.Length; i++)
        {
            jewerlyCountText[i].text = count[i].ToString();
        }
    }
    public void SetCount(int grade, int n)
    {
        if (grade == 1)
        {
            count[0] = n;           
        }            
        else if (grade == 2)
        {
            count[1] = n;           
        }
           
        else if (grade == 3)
        {
            count[2] = n;          
        }
        else if (grade == 4)
        {
            count[3] = n;            
        }
        else
        {
            count[4] = n;          
        }
    }

   
}
