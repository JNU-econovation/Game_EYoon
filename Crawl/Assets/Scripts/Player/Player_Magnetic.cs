using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Magnetic : MonoBehaviour
{
    bool isMagnet;
    Player _player;
    Item_Copper item_Copper;
    Item_Silver item_Silver;
    Item_Gold item_Gold;
    Item_Diamond item_Diamond;
    Item_Ruby item_Ruby;
    public Collider2D[] items;
    public LayerMask layerMask;
    float time;
    float magnetTime;
    void Start()
    {
        _player = GetComponent<Player>();
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
        if (!_player.GetIsPause())
        {
            if (isMagnet)
            {
                time += Time.deltaTime;
                if (time >= magnetTime)
                {
                    isMagnet = false;
                    Window.Instance.UnMagnet();
                }
            }
        }
        items = Physics2D.OverlapCircleAll(transform.position,  250.0f, layerMask, 0, 20);
    }

    public void Magnet(float temp)
    {
        Window.Instance.Magnet();
        time = 0;
        magnetTime = temp;
        isMagnet = true;
    }
    
}
