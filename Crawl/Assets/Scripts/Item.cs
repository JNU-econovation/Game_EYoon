using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
abstract public class Item : Singleton<Item>
{
    public int grade;
    public Text text;
    protected int get_jewerly_multiple = 1;
    void Start()
    {
        StartCoroutine(DestroySelf());
    }

    IEnumerator DestroySelf()
    {
        yield return new WaitForSeconds(4.0f);
        Destroy(gameObject);
    }
    public void SetMultiple(int n)
    {
        get_jewerly_multiple = n;
    }
    abstract public void IncreaseCount(int n);

    abstract public int GetCount();
    abstract public int GetMaxCount();
    abstract public void SetMaxCount(int n);
    abstract public void ResetCount();
    abstract public void DecreaseMaxCount(int n);
    abstract public void IncreaseMaxCount(int n);
}
