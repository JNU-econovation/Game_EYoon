using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WindowHP : MonoBehaviour
{
    public float HP;
    public float maxHP;
    int count = 0;
    float temp = 0;
    public Sprite[] brokenWindow;
    public SpriteRenderer sr;
    public Image hpImage;
    void Start()
    {
        hpImage = gameObject.GetComponentInChildren<Image>();
        maxHP = HP;
        sr = GetComponent<SpriteRenderer>();
    }
    public void ChangeWindow()
    {
        if (maxHP * (1 - temp - 0.25f) <= HP && HP < maxHP * (1 - temp))
            sr.sprite = brokenWindow[count];
        else if (HP <= 0)
            sr.sprite = brokenWindow[brokenWindow.Length-1];
        temp += 0.25f;
        count++;
    }

}
