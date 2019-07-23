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
    public Sprite originWindowSprite;
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

        if (collider.gameObject.tag == "Player")
        {
            movedPosition = transform.position + moving;
            GetComponentInParent<WindowList>().transform.position += moving;

            List<GameObject> windows = GetComponentInParent<WindowList>().windows;
            foreach(var window in windows)
            {
                Color color = window.GetComponent<Window>().originColor;
                window.GetComponent<Window>().window.GetComponent<SpriteRenderer>().sprite = originWindowSprite;
                window.GetComponent<Window>().window.GetComponent<SpriteRenderer>().color = color;
                window.GetComponent<Window>().isBroken = false;

            }
        }       

    }
}
