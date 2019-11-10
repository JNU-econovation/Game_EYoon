using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UI_SkillButton : MonoBehaviour
{
    int skillNum = 1;
    List<UI_Slot> slots = new List<UI_Slot>();
    public GameObject slot0;
    float slot0_Pos;
    public Text skillText;
    UI_SkillText ui_SkillText;
    bool isSkillChosen;
    bool isStop;
    private void Awake()
    {
        ui_SkillText = skillText.GetComponent<UI_SkillText>();
        UI_Slot[] ui_slots = GetComponentsInChildren<UI_Slot>();
        foreach (var slot in ui_slots)
        {
            slots.Add(slot); 
        }
        slot0_Pos = slot0.GetComponent<RectTransform>().localPosition.y;
        
    }
    
    IEnumerator StopSlots()
    {
        while (true)
        {         
            yield return null;
            if (isSkillChosen)
            {
               
                float distance = Mathf.Abs(slots[skillNum].transform.localPosition.y - slot0_Pos);              
                if (distance <= 10.0f)
                {
                    isStop = true;
                    slots[skillNum].transform.localPosition = new Vector3(0, 0, 0);
                    ui_SkillText.SetText(slots[skillNum].GetComponent<Skill>().GetSkillText());                   
                    isSkillChosen = false;
                }
            }
            
        }
    }
    private void OnEnable()
    {
        StartCoroutine(StopSlots());
    }
    public bool GetisSkillChosen()
    {
        return isSkillChosen;
    }
    public bool GetIsStop()
    {
        return isStop;
    }
    public void SetIsStop(bool temp)
    {
        isStop = temp;
    }
    public void SetisSkillChosen(bool temp)
    {
        isSkillChosen = temp;
    }
    public void SetSkillNum(int n)
    {
        skillNum = n;
    }
    public int GetSkillNum()
    {
        return skillNum;
    }  
  
  
}
