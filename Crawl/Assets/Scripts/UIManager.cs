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
    public Text heightText;
    public float height;
    float time = 0;
    GameObject player;
    public GameObject gameover_UI;
    void Start()
    {
        item[0] = new Item_Copper();
        item[1] = new Item_Silver();
        item[2] = new Item_Gold();
        item[3] = new Item_Diamond();
        item[4] = new Item_Ruby();
        player = LevelManager.Instance.GetPlayer();
        StartCoroutine(Change_JewerlyTextColor());
    }
       
    IEnumerator Change_JewerlyTextColor()
    {
        while (true)
        {
            yield return null;
            int level = LevelManager.Instance.level;
            if (level >= 2)
            {
                for(int i = 0; i < 5; i++)
                {
                    jewerlyCountText[i].color = new Color(255, 255, 255, 255);
                  
                }
                break;
            }
        }
    }
    public void OnSkillUI(int i)
    {
        skillUI[i-1].gameObject.SetActive(true);       
    }
      
   
    private void Update()
    {
        height = (int)((player.transform.position.y - 400) / 20);
        heightText.text = height + "m";      
    }
    public void SetCount(int grade, int n)
    {
        jewerlyCountText[grade - 1].text = n.ToString();        
    }

   
}
