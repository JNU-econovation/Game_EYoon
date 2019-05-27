using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowHP : MonoBehaviour
{
    public int HP;
    int maxHP;
    int count = 0;
    float temp = 0;
    [SerializeField] Sprite[] brokenWindow;
    SpriteRenderer sr;
    private void Start()
    {
        maxHP = HP;
        sr = gameObject.GetComponent<SpriteRenderer>();
    }
    public void ChangeWindow()
    {

        if (maxHP * (1 - temp - 0.25f) <= HP && HP < maxHP * (1 - temp))
            sr.sprite = brokenWindow[count];
        temp += 0.25f;
        count++;


    }

}
