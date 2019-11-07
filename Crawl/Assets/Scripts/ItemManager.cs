using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ItemManager : Singleton<ItemManager>
{
    [SerializeField] GameObject[] items;
    [SerializeField] float[] itemWeight;
  
    public GameObject SelectItem()
    {
        float rand = Random.Range(0, 100);
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
