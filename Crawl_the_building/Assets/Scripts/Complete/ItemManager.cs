using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class ItemManager : Singleton<ItemManager>
{
    float rand;
    //총알 치료 갑옷 우비 소화기 패딩 골드 무기 1~5렙 빈템 순
    public float[] weight = { 0.0f, 0.0f, 0.0f, 0.0f, 0.0f, 0.0f, 0.0f, 0.0f, 0.0f, 0.0f, 0.0f, 0.0f, 0.0f };
    public GameObject bulletItem;
    public GameObject healItem;
    public GameObject armorItem;
    public GameObject raincoatItem;
    public GameObject fireExItem;
    public GameObject jacketItem;
    public GameObject coinItem;
    public GameObject weaponLv1;
    public GameObject weaponLv2;
    public GameObject weaponLv3;
    public GameObject weaponLv4;
    public GameObject weaponLv5;
    public GameObject nullItem;
    List<GameObject> item = new List<GameObject>();       

    private void Awake()
    {        
        item.Add(bulletItem);
        item.Add(healItem);
        item.Add(armorItem);
        item.Add(raincoatItem);
        item.Add(fireExItem);
        item.Add(jacketItem);
        item.Add(coinItem);
        item.Add(weaponLv1); 
        item.Add(weaponLv2);
        item.Add(weaponLv3);
        item.Add(weaponLv4);
        item.Add(weaponLv5);
        item.Add(nullItem);
    }
    
    public int SelectIndex(float[] weight)
    {
        rand = Random.Range(0, 100);
        float total = 0;        
        for(int i = 0; i < weight.Length; i++)
        {
            total += weight[i];
            if (rand <= total)
                return i;            
        }
        return weight.Length - 1;
    }
  
    public GameObject MakeItem(Vector3 vector3)
    { 
        int i = SelectIndex(weight);        
        item[i].transform.position = vector3;        
        GameObject temp = Instantiate(item[i]);
        return temp;
    }  

}
