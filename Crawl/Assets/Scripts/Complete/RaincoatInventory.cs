using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RaincoatInventory : Singleton<RaincoatInventory>
{
    int raincoatLevel = 0;
    int maxLevel = 5;
    Text levelText;

    private void Start()
    {
        levelText = GetComponentInChildren<Text>();
    }
    public void InsertItem(Sprite itemImage)
    {
      //  GetComponent<Image>().sprite = itemImage;
        raincoatLevel++;
        if (raincoatLevel >= maxLevel)
            raincoatLevel = maxLevel;
        levelText.text = raincoatLevel.ToString();
        
    }
}
