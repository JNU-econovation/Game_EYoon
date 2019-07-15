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
    Manager Manager;
    [SerializeField] GameObject roofTop;
    List<GameObject> windows = new List<GameObject>();
    bool roof = true;

    void Start()
    {
        windows = map.GetComponent<WindowList>().windows;
        player = service.GetComponent<LevelManager>().player;
        move = new Vector3(0, moveDistance, 0);
        movedPosition = map.transform.position + move;
        Manager = service.GetComponent<Manager>();

    }
    private void Update()
    {
        if (movedPosition.y >= Height.Instance.maxHeight)
        {
            gameObject.SetActive(false);
            GetComponentInParent<WindowList>().DisableFloor();           
        }
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {

        if (collider.gameObject == player && Manager.height < 500)
        {
            movedPosition = map.transform.position + move;
            map.transform.position = movedPosition;

            for (int i = 0; i < windows.Count; i++)
            {
                float hp = windows[i].GetComponent<Window>().HP;
                float maxhp = windows[i].GetComponent<Window>().maxHP;

                if (hp != maxhp)
                {
                    service.GetComponent<LevelManager>().RecoverWindows(windows[i]);
                }
            }

        }
        else if (collider.gameObject == player && Manager.height > 500 && roof == true)
        {
            roof = false;
            roofTop.transform.position = move;
        }


    }
}
