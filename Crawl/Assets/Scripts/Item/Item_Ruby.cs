using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_Ruby : Item
{
    static int remainCount;
    static int count = 0;
    static int maxCount = 10;
    private void Start()
    {
        player = LevelManager.Instance.GetPlayer();
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        SoundManager.Instance.PlayItemSound();
        if (collider.gameObject.tag == "Player")
        {
            count += get_jewerly_multiple;
            if (count >= maxCount)
            {
                UIManager.Instance.OnSkillUI(5);
                IncreaseMaxCount(5);
                count = 0;
            }
            remainCount = maxCount - count;
            UIManager.Instance.SetCount(5, remainCount);
            Destroy(gameObject);
        }
    }
    private void Update()
    {
        remainCount = maxCount - count;
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
            UIManager.Instance.OnSkillUI(4);
            IncreaseMaxCount(5);
            count = 0;
        }
    }

    public override void ResetCount()
    {
        count = 0;
    }
    public override void DecreaseMaxCount(int n)
    {
        maxCount -= n;
        if (maxCount <= 0)
            maxCount = 0;
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
    public override int GetRemainCount()
    {
        return remainCount;
    }
}
