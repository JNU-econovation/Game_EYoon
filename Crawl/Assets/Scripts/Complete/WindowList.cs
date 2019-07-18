using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowList : Singleton<WindowList>
{
    public GameObject service;
    public List<GameObject> windows = new List<GameObject>();
    public GameObject[] floorArr;
    public GameObject[] map;
    private void Awake()
    {       
        Window[] window = GetComponentsInChildren<Window>();
        foreach (var obj in window)
            windows.Add(obj.gameObject);
        
    }
   
    public void DisableFloor()
    {
        float maxHeight = service.GetComponent<LevelManager>().maxHeight;
        for (int i = 0; i < floorArr.Length; i++)
        {
            if (floorArr[i].transform.position.y > maxHeight + 10)
                floorArr[i].SetActive(false);
        }
    }

}
