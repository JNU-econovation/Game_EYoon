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
   
   

}
