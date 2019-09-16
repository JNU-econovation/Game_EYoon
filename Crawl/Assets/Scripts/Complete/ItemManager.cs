using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class ItemManager : Singleton<ItemManager>
{
    float rand;
    //빈템 치료 우비 소화기 패딩 골드 무기 1~5렙 방어구 1~5렙 순
    public float[] weight;
    public List<GameObject> item = new List<GameObject>();       

    public int SelectIndex(float[] weight)
    {
        rand = Random.Range(0, 100);
        float total = 0;
        int i = 0;
        while(i< weight.Length)
        {
            total += weight[i];
            if (rand <= total)
                return i;
            i++;
        }
        return weight.Length - 1;
    }
  
    public GameObject MakeItem(Vector3 vector3, float[] weight)
    {
      //  weight = LevelManager.Instance.ChangeItemWeight();
        int i = SelectIndex(weight);
        return Instantiate(item[i], vector3, Quaternion.identity);
    }
    public void MakeItem(Vector3 vector3, float[] weight, int a)
    {
     //   weight = LevelManager.Instance.ChangeItemWeight();
        int i = SelectIndex(weight);
        vector3 += new Vector3(0, 20, 0);
        GameObject temp = Instantiate(item[i], vector3, Quaternion.identity);
        temp.GetComponent<Rigidbody2D>().gravityScale = 4;
    }
}
