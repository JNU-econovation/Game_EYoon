using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_SkillUI : MonoBehaviour
{
    List<UI_SkillButton> skillButtons = new List<UI_SkillButton>();
    GameObject[] slots;
    [SerializeField] int jewerlyNum;
    Player_Invincibility player_Invincibility;
    public GameObject panel;
    public GameObject joyStick;
    private void Awake()
    {
        GameObject player = LevelManager.Instance.GetPlayer();
        player_Invincibility = player.GetComponent<Player_Invincibility>();
        slots = GameObject.FindGameObjectsWithTag("Slot");
       
        UI_SkillButton[] buttons = GetComponentsInChildren<UI_SkillButton>();
        foreach (var button in buttons)
        {
            skillButtons.Add(button);
        }
   
    }
    private void OnEnable()
    {
        joyStick.SetActive(false);
        panel.SetActive(false);
        LevelManager.Instance.Pause();
        SoundManager.Instance.PlaySkillSound();
        for (int i = 0; i < slots.Length; i++)
        {
            slots[i].SetActive(true);
        }        
        ChooseSkill();
    }
    private void OnDisable()
    {
        joyStick.SetActive(true);
        panel.SetActive(true);
        SoundManager.Instance.skillAudioSource.Stop();
        player_Invincibility.Skill_end_Invince(0.5f);
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

