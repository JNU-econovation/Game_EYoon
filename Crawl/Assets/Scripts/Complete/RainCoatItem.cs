using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainCoatItem : Item
{
    public float increase;
    bool isRain;
    public GameObject rainMaker;

    public override void Function()
    { 
        RaincoatInventory.Instance.InsertItem(itemImage);
        isRain = WeatherManager.Instance.isRain;
        if (isRain)
        {
            print(isRain);
            rainMaker.GetComponent<RainMaker>().RecoverStaminaSpeed();
        }       
    }   

    
}
