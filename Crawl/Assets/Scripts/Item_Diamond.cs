﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_Diamond : Item
{
    static int count = 0;
    static int maxCount = 100;
    private void Start()
    {
        player = LevelManager.Instance.GetPlayer();
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            IncreaseCount(get_jewerly_multiple);
            UIManager.Instance.SetCount(4, count);
            Destroy(gameObject);
        }
    }
    private void Update()
    {
        if (isMagent)
        {
            transform.Translate((player.transform.position - transform.position).normalized * Time.deltaTime * 500);
        }
    }
    public override int GetCount()
    {
        return count;
    }

    public override void IncreaseCount(int n)
    {
        count += n;
        if (count >= maxCount)
        {
            UIManager.Instance.OnSkillUI(3);
            count -= maxCount;
        }
        
    }
    public override void ResetCount()
    {
        count = 0;
    }
    public override void DecreaseMaxCount(int n)
    {
        maxCount -= n;
        if (maxCount <= 1)
            maxCount = 1;
    }
    public override void IncreaseMaxCount(int n)
    {
        maxCount += n;
    }
    public override int GetMaxCount()
    {
        return maxCount;
    }
    public override void SetMaxCount(int n)
    {
        maxCount = n;
    }
}
