using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeMap : MonoBehaviour
{
    Vector3 moving;
    GameObject player;
    public GameObject service; 
    Vector3 movedPosition;
    public float moveDistance;
    List<GameObject> windows = new List<GameObject>();
    void Start()
    {
        windows = GetComponentInParent<WindowList>().windows;
        player = service.GetComponent<LevelManager>().player;
        moving = new Vector3(0, moveDistance, 0);

    }

    private void Update()
    {
       float maxHeight = service.GetComponent<LevelManager>().maxHeight;
       if (movedPosition.y >= maxHeight)
        {
            gameObject.SetActive(false);
            GetComponentInParent<WindowList>().DisableFloor();           
        }
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {

        if (collider.gameObject == player)
        {
            movedPosition = transform.position + moving;
            GetComponentInParent<WindowList>().transform.position += moving;

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

    }
}
