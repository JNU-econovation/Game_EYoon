using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIManager : Singleton<UIManager>
{
  
    public Text[] jewerlyCountText;
    public GameObject[] skillUI;   
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
        skillUI[i].gameObject.SetActive(true);       
    }
      
   /*
    private void Update()
    {
        for (int i = 0; i < item.Length; i++)
        {
            jewerlyCountText[i].text = item[i].GetCount().ToString();
        }
    }*/
    public void SetCount(int grade, int n)
    {
        jewerlyCountText[grade - 1].text = n.ToString();        
    }

   
}
