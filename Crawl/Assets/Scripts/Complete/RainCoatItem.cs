using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainCoatItem : Item
{
    public float increase;
    bool isRain;
    public GameObject rainMaker;
    private void Start()
    {
        
    }
    public override void Function()
    {
        isRain = WeatherManager.Instance.isRain;
        if (isRain)
        {
            print(isRain);
            rainMaker.GetComponent<RainMaker>().RecoverStaminaSpeed();
        }
        Inventory2.Instance.InsertItem(itemImage);
    }   

    
}
