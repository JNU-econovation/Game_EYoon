using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FireExInventory : Singleton<FireExInventory>
{
    public int fireExCount = 0;
    int maxfireExCount = 5;
    Text levelText;
    public GameObject service;
    GameObject player;
    private void Start()
    {
        levelText = GetComponentInChildren<Text>();
        player = service.GetComponent<LevelManager>().player;
    }
    public void InsertItem(Sprite itemImage)
    {
        GetComponent<Image>().sprite = itemImage;
        fireExCount++;
        if (fireExCount >= maxfireExCount)
        {
            fireExCount = maxfireExCount;            
        }
        levelText.text = fireExCount.ToString();
    }
}
