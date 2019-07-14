using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArmorInventory : Singleton<ArmorInventory>
{
    int armorLevel = 0;    
    Text levelText;
    private void Start()
    {
        levelText = GetComponentInChildren<Text>();
    }
    public void InsertItem(Sprite itemImage, int level)
    {
        if (level > armorLevel)
        {
            GetComponent<Image>().sprite = itemImage;
            armorLevel = level;
        }
        levelText.text = armorLevel.ToString();
    }
}
