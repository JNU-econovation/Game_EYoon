using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArmorInventory : Singleton<ArmorInventory>
{
    int armorLevel = 0;    
    Text levelText;
    public GameObject service;
    GameObject player;
    private void Start()
    {
        levelText = GetComponentInChildren<Text>();
        player = service.GetComponent<LevelManager>().player;
    }
    public void InsertItem(Sprite itemImage, int level)
    {
        if (level > armorLevel)
        {
            GetComponent<Image>().sprite = itemImage;
            armorLevel = level;
            player.GetComponent<Ability>().armor = armorLevel * 10;
        }
        levelText.text = armorLevel.ToString();
    }
}
