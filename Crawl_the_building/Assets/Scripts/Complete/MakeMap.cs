using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeMap : MonoBehaviour
{
    Vector3 move;
    GameObject player;
    public GameObject service;
    public GameObject map;   
    Vector3 movedPosition;
    public float moveDistance;
    List<GameObject> windows = new List<GameObject>();

    void Start()
    {
        windows = map.GetComponent<WindowList>().windows;
        player = service.GetComponent<LevelManager>().player;
        move = new Vector3(0, moveDistance, 0);
        movedPosition = map.transform.position + move;

    }
    private void OnTriggerEnter2D(Collider2D collider)
    {

        if (collider.gameObject == player)
        {
            movedPosition = map.transform.position + move;
            map.transform.position = movedPosition;            
           
            for(int i = 0; i < windows.Count; i++)
            {
                float hp = windows[i].GetComponent<Window>().HP;
                float maxhp = windows[i].GetComponent<Window>().maxHP;

                if (hp != maxhp)
                {                    
                    service.GetComponent<LevelManager>().RecoverWindows(windows[i]);
                }
            }
            
        }

    }
}
