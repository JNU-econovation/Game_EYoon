using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_Silver : Item
{
    static int count = 0;
    protected int maxCount = 10;
    public override int GetCount()
    {
        return count;
    }

  
    public override void IncreaseCount()
    {
        count++;
        if (count == maxCount)
        {
            UIManager.Instance.OnSkillUI(1);
        }
    }
    public override void ResetCount()
    {
        count = 0;
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
        if (collider.gameObject.tag == "Player")
        {
            IncreaseCount();
            UIManager.Instance.SetCount(grade, count);
            Destroy(gameObject);
        }
    }

    public override void DecreaseMaxCount(int n)
    {
        maxCount -= n;
    }
    public override void IncreaseMaxCount(int n)
    {
        maxCount += n;
    }
}
