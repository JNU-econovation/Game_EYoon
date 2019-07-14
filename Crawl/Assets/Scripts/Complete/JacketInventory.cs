using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JacketInventory : Singleton<JacketInventory>
{
    Text levelText;
    private void Start()
    {
        levelText = GetComponentInChildren<Text>();
    }
    public void InsertItem(Sprite itemImage, int level)
    {
        GetComponent<Image>().sprite = itemImage;   
        levelText.text = level.ToString();
    }
}
