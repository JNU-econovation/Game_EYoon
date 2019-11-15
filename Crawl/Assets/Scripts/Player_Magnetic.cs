using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Magnetic : MonoBehaviour
{
    bool isMagnet;
    Item_Copper item_Copper;
    Item_Silver item_Silver;
    Item_Gold item_Gold;
    Item_Diamond item_Diamond;
    Item_Ruby item_Ruby;
    public Collider2D[] items;
    public LayerMask layerMask;
    void Start()
    {
        StartCoroutine(OnMagnet());
    }
    IEnumerator OnMagnet()
    {
        while (true)
        {
            if (isMagnet)
            {
                for (int i = 0; i < items.Length; i++)
                {
                    if (items[i] != null)
                    {
                        items[i].GetComponent<Item>().Magnet();
                    }
                }
            }
            else
            {
                for (int i = 0; i < items.Length; i++)
                {
                    if (items[i] != null)
                    {
                        items[i].GetComponent<Item>().UnMagnet();
                    }
                }
            }
            yield return null;
        }
    }
    private void Update()
    {
        items = Physics2D.OverlapCircleAll(transform.position,  250.0f, layerMask, 0, 20);
    }

    public void Magnet(float delayTime)
    {
        Window.Instance.Magnet();
        isMagnet = true;
        StartCoroutine(Delay(delayTime));
    }
    IEnumerator Delay(float delayTime)
    {
        yield return new WaitForSeconds(delayTime);
        isMagnet = false;
        Window.Instance.UnMagnet();
    }
}
