using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowList : MonoBehaviour
{
    Window[] window;
    public GameObject service;
    GameObject player;
    public GameObject[] map;
    public GameObject playerNearMap;
    public List<GameObject> windows = new List<GameObject>();

    private void Start()
    {
        playerNearMap = map[0];
    }
    private void Awake()
    {       
        window = GetComponentsInChildren<Window>();
        foreach (var obj in window)
            windows.Add(obj.gameObject);
        
    }
    
}
