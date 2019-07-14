using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponInventory : Singleton<WeaponInventory>
{
    int weaponLevel = 0;
    Text levelText;
    private void Start()
    {
        levelText = GetComponentInChildren<Text>();
    }
    public void InsertItem(Sprite itemImage, int level)
    {
        if (level > weaponLevel)
        {
            GetComponent<Image>().sprite = itemImage;
            weaponLevel = level;
        }
        levelText.text = weaponLevel.ToString();


    }
}
