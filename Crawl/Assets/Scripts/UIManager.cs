using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIManager : Singleton<UIManager>
{
  
    public Text[] jewerlyCountText;
    public Text avoidText;
    public GameObject[] skillUI;   
    bool onSkill;
    Item[] item = new Item[5];
    SkillManager skillManager;
    public Text heightText;
    float height = 0;
    float time = 0;
    GameObject player;
    public GameObject gameover_UI;
    public GameObject[] bossClear_SKill;
    public GameObject[] bossApproach_Text;
    public GameObject panel;
    public GameObject joyStick;
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

    public float GetHeight()
    {
        return height;
    }
    public void SetHeight(float n)
    {
        height = n;
    }

    public void OnSkill_BossClear(int n)
    {
        StartCoroutine(Delay(n));
    }
    IEnumerator Delay(int n)
    {
        yield return new WaitForSeconds(1);
        bossClear_SKill[n].SetActive(true);
    }
    public void OnBossApproach_Text(int n)
    {
        bossApproach_Text[n].SetActive(true);
    }
}
