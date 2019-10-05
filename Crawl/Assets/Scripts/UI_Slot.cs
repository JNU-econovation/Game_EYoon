using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UI_Slot : MonoBehaviour
{
    float moveSpeed = 1000;
    float time;
    bool waitTwoSecond;
    public int slotNum;
    public GameObject scroll;
    int button_skillNum;
    public string skillName;
    Skill skill;
    float variation;
    private void Start()
    {
        skill = GetComponent<Skill>();
        variation = skill.GetVariation();
    }
    private void Update()
    {
        time += Time.deltaTime;
        if (time >= 2.0f)
        {
            waitTwoSecond = true;
        }
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
    public bool Getwait()
    {
        return waitTwoSecond;
    }
    public string GetSkillName()
    {
        return skillName;
    }
    public void Stop()
    {
        moveSpeed = 0;
    }
    public float GetVariation()
    {
        return variation;
    }
}
