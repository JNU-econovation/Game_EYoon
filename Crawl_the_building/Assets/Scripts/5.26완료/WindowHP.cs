using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WindowHP : MonoBehaviour
{
    public float HP;
    public float maxHP;
    int count = 0;
    float temp = 0;
    public Sprite[] brokenWindow;
    public SpriteRenderer sr;
    public Image hpImage;
    ItemManager itemManager;
    bool itemMade;
    void Start()
    {
        itemMade = false;
        itemManager = GetComponent<ItemManager>(); 
        hpImage = gameObject.GetComponentInChildren<Image>();
        sr = GetComponent<SpriteRenderer>();
    }
    public void ChangeWindow()
    {
        if (maxHP * (0.66f) <= HP && HP < maxHP)
        {
            sr.sprite = brokenWindow[0];
        }
        else if (maxHP * (0.33f) <= HP && HP < maxHP * 0.66f)
        {
            sr.sprite = brokenWindow[1];
        }
        else if (0 < HP && HP < maxHP * 0.33f)
        {
            sr.sprite = brokenWindow[2];
        }
        else if (HP <= 0 && itemMade == false)
        {
            sr.sprite = brokenWindow[3];
            itemManager.SelectItem(gameObject.transform.position);
            itemMade = true;
        }
    }   

}
