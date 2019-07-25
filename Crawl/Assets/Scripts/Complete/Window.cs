using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Window : MonoBehaviour
{
    public bool isBroken = false;
    public GameObject window;
    public Sprite breakWindow1;
    public Sprite breakWindow2;
    public Color originColor;

    private void Start()
    {
        originColor = window.GetComponent<SpriteRenderer>().color;
    }
    public void BreakWindow()
    {
        window.GetComponent<SpriteRenderer>().sprite = breakWindow1;
        window.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 255);
        int rand = Random.Range(0, 2);
        if(rand == 0)
             GetComponent<AudioSource>().enabled = true;
        float[] weight = ItemManager.Instance.weight;
        ItemManager.Instance.MakeItem(gameObject.transform.position, weight);     
        isBroken = true;
    }   

}
