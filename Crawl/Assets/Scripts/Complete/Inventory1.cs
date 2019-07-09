using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Inventory1 : Singleton<Inventory1>
{
    public Sprite inventoryImage;
    public Text text;
    public int weaponLevel = 0;
    public void InsertItem(Sprite itemImage, int level)
    {
        if (level > weaponLevel)
        {
            GetComponent<Image>().sprite = itemImage;
            text.gameObject.SetActive(false);
            weaponLevel = level;
        }
    }
}
