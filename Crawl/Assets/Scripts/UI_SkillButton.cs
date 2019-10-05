using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UI_SkillButton : MonoBehaviour
{
    int skillNum = -1;
    List<UI_Slot> slots = new List<UI_Slot>();
    public GameObject slot0;
    float slot0_Pos;
    public Text skillText;
    UI_SkillText ui_SkillText;
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
    private void Start()
    {
        StartCoroutine(StopSlots());
    }
    IEnumerator StopSlots()
    {
        while (true)
        {
            yield return null;
            if(skillNum != -1)
            {
                                                              
                float distance = Mathf.Abs(slots[skillNum].transform.localPosition.y - slot0_Pos);
                if (distance <= 100.0f)
                {
                    slots[skillNum].transform.localPosition = new Vector3(0, 0, 0);
                    string str = "(" + slots[skillNum].GetVariation() + ")";
                    ui_SkillText.SetText(slots[skillNum].GetSkillName() + str);
                    for (int i = 0;i< slots.Count; i++)
                    {
                        
                        slots[i].Stop();
                    }
                    break;
                }
            }
        }
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
