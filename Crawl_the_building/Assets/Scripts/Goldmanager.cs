using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goldmanager : MonoBehaviour
{
    public int Goldamount;

    private void Start()
    {
        Goldchange(120);
    }

    void Goldchange(int price)
    {
        Goldamount += price;
        PlayerPrefs.SetInt("Gold", Goldamount);
        
    }
   
  
}
