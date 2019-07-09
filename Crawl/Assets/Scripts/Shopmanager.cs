using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shopmanager : MonoBehaviour
{
    [SerializeField] Sprite soldout;
    public List<Transform> shoptables;
    [SerializeField] Transform content;
    int price;
    int gold;



    private void Start()
    {
        int contentLength = content.childCount;
        
        for(int i= 0; i < contentLength; i++)
        {
            Transform tables = content.GetChild(i);
            shoptables.Add(tables);
        }
    }

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
