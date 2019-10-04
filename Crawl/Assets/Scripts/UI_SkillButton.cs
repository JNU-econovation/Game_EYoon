using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_SkillButton : MonoBehaviour
{
    public int skillNum;
    List<UI_SlotMachine> slots = new List<UI_SlotMachine>();
    private void Start()
    {
        UI_SlotMachine[] uI_SlotMachines = GetComponentsInChildren<UI_SlotMachine>();
        foreach(var slot in uI_SlotMachines)
        {
            slots.Add(slot);
        }
        ShakeSlots();
    }
    public void SetSkillNum(int n)
    {
        skillNum = n;
    }
    public int GetSkillNum()
    {
        return skillNum;
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
       
        int slotNum = collider.gameObject.GetComponent<UI_SlotMachine>().GetSlotNum();
        bool isWaited = collider.gameObject.GetComponent<UI_SlotMachine>().Getwait();
        if (skillNum == slotNum && isWaited)
        {
            for (int i = 0; i < slots.Count; i++)
            {
                slots[i].Stop();
            }
        }
    }

    void ShakeSlots()
    {
        for (int i = 0; i < slots.Count; i++)
        {
            int a = i;
            int b = Random.Range(0, slots.Count-1);
            slots[a].SetSlotNum(a);
            slots[b].SetSlotNum(b);
        }

    }
}
