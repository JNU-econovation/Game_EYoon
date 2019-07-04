using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Abilitymanager : MonoBehaviour
{
    int price;
    int gold;
    string statname;
    public GameObject Character;
    
    // Start is called before the first frame update 

    public void Upgrade(GameObject button)
    {
        price = button.GetComponentInChildren<Pricetag>().price;
        gold = PlayerPrefs.GetInt("Gold");
        statname = Character.name + button.name;
        if(price <= gold)
        {
            int statvalue = PlayerPrefs.GetInt(statname) + 1;
            button.GetComponentInChildren<Pricetag>().Addprice();
            PlayerPrefs.SetInt(statname, statvalue);
            PlayerPrefs.SetInt("Gold", gold - price);
            
        }
    }
   
}
