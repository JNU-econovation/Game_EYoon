using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Inventory2 : Singleton<Inventory2>
{
    public Sprite inventoryImage;
    public void InsertItem(Sprite itemImage)
    {
        GetComponent<Image>().sprite = itemImage;
    }
}
