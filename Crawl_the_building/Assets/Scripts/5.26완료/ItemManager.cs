using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    int rand;
    Item item;
    public GameObject bullet;
    public GameObject heal;
    public void SelectItem(Vector3 vector3)
    {
        rand = Random.Range(1, 100);
        print(rand);
        if(1<=rand && rand <= 33)
        {
            MakeItem(bullet, vector3);         
        }
        else if(34<= rand && rand <= 66)
        {
            MakeItem(heal, vector3);
        }  
    }
    public void MakeItem(GameObject obj, Vector3 vector3)
    {
        obj.transform.position = vector3;
        Instantiate(obj);
    }

}
