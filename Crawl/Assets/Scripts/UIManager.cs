using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIManager : Singleton<UIManager>
{
  
    public Text[] jewerlyCountText;
    public GameObject skillUI;   
    int[] count = new int[5];
    bool onSkill;
    Item[] item = new Item[5];
    SkillManager skillManager;
    float time = 0;
    void Start()
    {
        item[0] = new Item_Copper();
        item[1] = new Item_Silver();
        item[2] = new Item_Gold();
        item[3] = new Item_Diamond();
        item[4] = new Item_Ruby();
        
           
    }
       
    public void OnSkillUI(int i)
    {
        skillUI.gameObject.SetActive(true);
        item[i].ResetCount();
        ResetCount(i);
    }
      
    void ResetCount(int i)
    {
        count[i] = 0;
    }
   
    private void Update()
    {
        for (int i = 0; i < count.Length; i++)
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
