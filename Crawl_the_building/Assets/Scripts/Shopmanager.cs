using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shopmanager : MonoBehaviour
{
    [SerializeField] Sprite soldout;
    public GameObject[] shoptables;
  public  void Shopping(GameObject button)
    {
        int price = button.GetComponentInChildren<Stuffprice>().price;
        int gold = PlayerPrefs.GetInt("Gold");
       
        if (price <= gold)
        {
            PlayerPrefs.SetInt("Gold", gold - price);
            button.SetActive(false);
        }
       
    }

  public void Soldout(int i)
    {
        shoptables[i].GetComponent<Image>().sprite = soldout;
    }
}
