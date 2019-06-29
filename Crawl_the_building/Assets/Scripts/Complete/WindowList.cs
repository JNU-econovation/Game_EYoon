using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowList : MonoBehaviour
{
    Window[] windows;
    public List<GameObject> window = new List<GameObject>();
    void Start()
    {
        windows = GetComponentsInChildren<Window>();
        foreach(var obj in windows)
        {
            window.Add(obj.gameObject);           
        }             
    }
    
}
