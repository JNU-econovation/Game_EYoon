using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ItemManager : MonoBehaviour
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

   

}
