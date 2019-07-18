using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AvoidText : Singleton<AvoidText>
{
    Text avoidText;
    public float lifeTime;
    private void Start()
    {
        avoidText = GetComponent<Text>();
        gameObject.SetActive(false);
    }

    IEnumerator DiableSelf(float lifeTime)
    {
        yield return new WaitForSeconds(lifeTime);
        gameObject.SetActive(false);
    }
    public void MakeAvoidText()
    {
        gameObject.SetActive(true);
        StartCoroutine(DiableSelf(lifeTime));

    }
}
