using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponInventory : Singleton<WeaponInventory>
{
    int weaponLevel = 0;
    Text levelText;
    GameObject player;
    public GameObject service;
    private void Start()
    {
        levelText = GetComponentInChildren<Text>();
     //   player = service.GetComponent<LevelManager>().player;
    }
    public void InsertItem(Sprite itemImage, int level)
    {
        if (level > weaponLevel)
        {
       //     GetComponent<Image>().sprite = itemImage;
            weaponLevel = level;
        //    player.GetComponent<Ability>().bulletDamage = weaponLevel * 10;
        }
     //   levelText.text = weaponLevel.ToString();


    }
}
