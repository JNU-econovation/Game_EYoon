using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map_Controler : MonoBehaviour
{
    public Sprite originalWindow_Sprite;
    public GameObject map;
    [SerializeField] GameObject player;
    List<Window> windows = new List<Window>();
    List<GameObject> near_Windows = new List<GameObject>();
    private void Start()
    {
        Window[] map_Windows = map.GetComponentsInChildren<Window>();
        foreach(var window in map_Windows)
        {          
            windows.Add(window);
        }
    }
    
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.tag == "Player")
        {
            InitializeWIndows();
            map.transform.Translate(0, 3600, 0);
        }
    }

    void InitializeWIndows()
    {
        for(int i = 0; i < windows.Count; i++)
        {
            windows[i].InitializeSprite();
            windows[i].setItemMade(false);
        }
    }
}
