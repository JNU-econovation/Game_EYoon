using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JacketInventory : Singleton<JacketInventory>
{
    Text levelText;
    public int jacketLevel = 0;
    int maxLevel = 5;
    private void Start()
    {
        levelText = GetComponentInChildren<Text>();
    }
    public void InsertItem(Sprite itemImage)
    {
    //    GetComponent<Image>().sprite = itemImage;
        jacketLevel++;
        if (jacketLevel >= maxLevel)
            jacketLevel = maxLevel;
        levelText.text = jacketLevel.ToString();
    }
}
