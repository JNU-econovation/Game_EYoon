using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowChanger : MonoBehaviour
{
    private SpriteRenderer sprite;
    public int WindowHp;
    public SpriteRenderer[] Windows;
    int count = 0;
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }
    public void windowChange()
    {
        int i;
        for (i = 0; i < WindowHp; i++)
        {
            Destroy(gameObject);
            Windows[i].sortingOrder = default;

        }
        Windows[count].sortingOrder = 1;

        count++;

    }
    
    void Update()
    {
        
    }
}
