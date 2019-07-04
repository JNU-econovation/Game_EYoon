using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shopmanager : MonoBehaviour
{
    [SerializeField] Sprite soldout;
    public GameObject[] shoptables;
    int price;
    int gold;
    
  public  void Shopping(GameObject button)
    {
         price = button.GetComponentInChildren<Pricetag>().price;
         gold = PlayerPrefs.GetInt("Gold");
       
        if (price <= gold)
        {
            PlayerPrefs.SetInt("Gold", gold - price);
            button.SetActive(false);
        }
       
    }

  public void Soldout(int i)
    {
        if (price <= gold)
        {
            shoptables[i].GetComponent<Image>().sprite = soldout;
        }
    }
}
