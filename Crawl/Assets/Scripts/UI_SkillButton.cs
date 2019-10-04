using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UI_SkillButton : MonoBehaviour
{
    int skillNum = 1;
    List<UI_SlotMachine> slots = new List<UI_SlotMachine>();
    List<Sprite> skill_sprites = new List<Sprite>();
    List<Image> slot_image = new List<Image>();
    Image image;
    public Sprite a;
    private void Awake()
    {
        image = GetComponent<Image>();
        UI_SlotMachine[] uI_SlotMachines = GetComponentsInChildren<UI_SlotMachine>();
        foreach (var slot in uI_SlotMachines)
        {
            slots.Add(slot);
            skill_sprites.Add(slot.gameObject.GetComponent<Image>().sprite);
            slot_image.Add(slot.GetComponent<Image>());
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
    }
    IEnumerator Wait(float seconds)
    {
        yield return new WaitForSeconds(seconds);

        for (int i = 0; i < slots.Count; i++)
        {
            slots[i].Stop();

        }

        image.sprite = skill_sprites[skillNum];
        slot_image[skillNum].sprite = null;
    }
}
