using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UI_Slot : MonoBehaviour
{
    float moveSpeed = 1000;
    public int slotNum;
    public GameObject scroll;
    int button_skillNum;
    public string skillName;
    Skill skill;
    float variation;
    Button button;
    UI_SkillButton uI_SkillButton;
    private void Start()
    {
        button = GetComponent<Button>();
        skill = GetComponent<Skill>();
        uI_SkillButton = GetComponentInParent<UI_SkillButton>();
        button.interactable = false;
    }
    private void OnEnable()
    {
        moveSpeed = 2000;
    }
    private void Update()
    {
        if (uI_SkillButton.GetIsStop())
            Stop();
        transform.Translate(0, -Time.deltaTime * moveSpeed, 0);
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {

        if (collider.gameObject == scroll)
        {
            transform.Translate(0, 1760, 0);
        }

    }
    public int GetSlotNum()
    {
        return slotNum;
    }
    public void SetSlotNum(int n)
    {
        slotNum = n;
    }
 
    public string GetSkillName()
    {
        return skillName;
    }
    public void Stop()
    {
        button.interactable = true;
        moveSpeed = 0;
    }
    public float GetVariation()
    {
        return skill.GetVariation();
    }
}
