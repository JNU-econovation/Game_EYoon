﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlanketAnim : MonoBehaviour
{

    public float lifeTime = 5.0f;
    public GameObject dark;
    public Sprite black;
    private void OnEnable()
    {
        StartCoroutine(DestroySelf());
    }

    public IEnumerator DestroySelf()
    {
        yield return new WaitForSeconds(lifeTime);
        Destroy(gameObject);
    }

    void Function()
    {
        StartCoroutine(Dark());       
    }
    public IEnumerator Dark()
    {
        yield return new WaitForSeconds(3.0f);
        dark.GetComponent<SpriteRenderer>().sprite = black;
    }
}
