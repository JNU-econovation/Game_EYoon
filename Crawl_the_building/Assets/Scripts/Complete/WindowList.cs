using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowList : MonoBehaviour
{
    Window[] window;
    public List<GameObject> windows = new List<GameObject>();
    void Awake()
    {
        window = GetComponentsInChildren<Window>();
        foreach(var obj in window)
        {
            windows.Add(obj.gameObject);           
        }             
    }
    

}
