using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FireExInventory : Singleton<FireExInventory>
{
    int fireExLevel = 0;
    int maxLevel = 5;
    Text levelText;
    private void Start()
    {
        levelText = GetComponentInChildren<Text>();
    }
    public void InsertItem(Sprite itemImage, int level)
    {
        GetComponent<Image>().sprite = itemImage;
        fireExLevel++;
        if (fireExLevel >= maxLevel)
            fireExLevel = maxLevel;
        levelText.text = level.ToString();
    }
}
