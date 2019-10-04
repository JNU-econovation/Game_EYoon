using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_Gold : Item
{
    static int count = 0;
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            IncreaseCount();
            UIManager.Instance.SetCount(grade, count);
            Destroy(gameObject);
        }
    }
    public override int GetCount()
    {
        return count;
    }

    public override void IncreaseCount()
    {
        count++;
    }
    public override void ResetCount()
    {
        count = 0;
    }
}
