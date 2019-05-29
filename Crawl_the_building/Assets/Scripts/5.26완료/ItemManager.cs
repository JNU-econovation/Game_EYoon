using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    Item item;
    int rand;
    int maxHave = 3;
    int haveItem;
    public GameObject bullet;

    public void SelectItem(Vector3 vector3)
    {   
        MakeItem(bullet, vector3);     
    }
    public void MakeItem(GameObject obj, Vector3 vector3)
    {
        obj.transform.position = vector3;
        Instantiate(obj);
    }
    
}
