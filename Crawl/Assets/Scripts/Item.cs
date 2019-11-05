using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
abstract public class Item : Singleton<Item>
{
    public int grade;
    public Text text;
    void Start()
    {
        StartCoroutine(DestroySelf());
    }

    IEnumerator DestroySelf()
    {
        yield return new WaitForSeconds(4.0f);
        Destroy(gameObject);
    }
 
    abstract public void IncreaseCount();

    abstract public int GetCount();
    abstract public int GetMaxCount();
    abstract public void SetMaxCount(int n);
    abstract public void ResetCount();
    abstract public void DecreaseMaxCount(int n);
    abstract public void IncreaseMaxCount(int n);
}
