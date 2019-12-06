using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_Silver : Item
{
    static int remainCount;
    static int count = 0;
    static int maxCount = 10;
    private void Start()
    {
        player = LevelManager.Instance.GetPlayer();
    }
    public override int GetCount()
    {
        return count;
    }

    private void Update()
    {
        remainCount = maxCount - count;
        if (isMagent)
        {
            transform.Translate((player.transform.position - transform.position).normalized * Time.deltaTime * 500);
        }
    }

    public override void IncreaseCount(int n)
    {
        count += n;
        if (count >= maxCount)
        {
            UIManager.Instance.OnSkillUI(1);
            IncreaseMaxCount(5);
            count = 0;
        }
    }
    public override void ResetCount()
    {
        count = 0;
        maxCount = 10;
    }

    public override int GetMaxCount()
    {
        return maxCount;
    }
    public override void SetMaxCount(int n)
    {
        maxCount = n;
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        SoundManager.Instance.PlayItemSound();
        if (collider.gameObject.tag == "Player")
        {
            count += get_jewerly_multiple;
            if (count >= maxCount)
            {
                UIManager.Instance.OnSkillUI(2);
                IncreaseMaxCount(5);
                count = 0;
            }
            remainCount = maxCount - count;
            UIManager.Instance.SetCount(2, remainCount);
            Destroy(gameObject);
        }
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

    public override int GetRemainCount()
    {
        return remainCount;
    }
}
