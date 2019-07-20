using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GoldScore : MonoBehaviour
{

    [SerializeField] Manager manager;
    
    // Start is called before the first frame update
    void Start()
    {
        string coin = manager.coinText.text;
        int coinAmount = int.Parse(coin);
        int gold = PlayerPrefs.GetInt("Gold");
        PlayerPrefs.SetInt("Gold", gold + coinAmount);
        GetComponent<Text>().text = coin + "G";
    }

  
}
