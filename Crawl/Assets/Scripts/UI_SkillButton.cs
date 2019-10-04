using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UI_SkillButton : MonoBehaviour
{
    int skillNum = 1;
    List<UI_SlotMachine> slots = new List<UI_SlotMachine>();
    List<Sprite> slot_Sprites = new List<Sprite>();
    Image image;
    private void Start()
    {
        image = GetComponent<Image>();
        UI_SlotMachine[] uI_SlotMachines = GetComponentsInChildren<UI_SlotMachine>();
        foreach(var slot in uI_SlotMachines)
        {
            slots.Add(slot);
            slot_Sprites.Add(slot.GetComponent<Image>().sprite);
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
  
    public void Stop()
    {
        StartCoroutine(Wait(2.0f));
        for (int i = 0; i < slots.Count; i++)
        {
            slots[i].Stop();
        }
        print(skillNum);
        image.sprite = slot_Sprites[skillNum];
    }
    IEnumerator Wait(float seconds)
    {
        yield return new WaitForSeconds(seconds);
    }
}
