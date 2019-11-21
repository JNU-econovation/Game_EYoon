using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ItemManager : Singleton<ItemManager>
{
    public GameObject[] items;
    [SerializeField] float[] itemWeight;
    public Item_Copper item_Copper;
    public Item_Silver item_Silver;
    public Item_Gold item_Gold;
    public Item_Diamond item_Diamond;
    public Item_Ruby item_Ruby;
    private void Start()
    {
        item_Copper = items[0].GetComponent<Item_Copper>();
        item_Silver = items[1].GetComponent<Item_Silver>();
        item_Gold = items[2].GetComponent<Item_Gold>();
        item_Diamond = items[3].GetComponent<Item_Diamond>();
        item_Ruby = items[4].GetComponent<Item_Ruby>();
    }
    public GameObject SelectItem()
    {
        float rand = Random.Range(0.01f, 100);
        float sum = 0;
        int i = 0;
        while (i < itemWeight.Length)
        {
            sum += itemWeight[i];
            if(rand <= sum)
            {
                return items[i];
            }
            i++;
        }        
        return items[0];
    }

    public float[] GetItemWeight()
    {
        return itemWeight;
    }

    public void SetItemWeight(float[] weight)
    {
        for(int i = 0; i < weight.Length; i++)
        {
            if (weight[i] <= 0)
                weight[i] = 0;
            if (weight[i] >= 100.0f)
                weight[i] = 100.0f;
        }
        itemWeight = weight;
    }
}
