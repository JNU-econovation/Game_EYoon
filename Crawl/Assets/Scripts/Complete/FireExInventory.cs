using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FireExInventory : Singleton<FireExInventory>
{
    public int fireExCount = 0;
    int maxfireExCount = 5;
    Text countText;
    public GameObject service;
    GameObject player;
    Color originalColor;
    float disableTime = 0.5f;

    private void Start()
    {
        originalColor = GetComponent<Image>().color;
        countText = GetComponentInChildren<Text>();
        countText.gameObject.SetActive(false);
        player = service.GetComponent<LevelManager>().player;
    }
    public void InsertItem(Sprite itemImage)
    {        
        fireExCount++;
        if (fireExCount >= maxfireExCount)
        {
            fireExCount = maxfireExCount;            
        }
        ChargeCount();
    }

    public void ChargeCount()
    {
        GetComponent<Image>().color = new Color(0,0,0);
        countText.text = fireExCount.ToString();
        countText.gameObject.SetActive(true);
        StartCoroutine(DisableText());
    }

    IEnumerator DisableText()
    {
        yield return new WaitForSeconds(disableTime);
        countText.gameObject.SetActive(false);
        GetComponent<Image>().color = originalColor;
    }

    public void FireOff()
    {
        if (fireExCount > 0)
        {
            foreach (var fire in service.GetComponent<LevelManager>().fireList)
            {
                Destroy(fire);
            }
            player.GetComponent<Ability>().DischargeFireExCount();
            fireExCount--;
            countText.text = fireExCount.ToString();
            countText.gameObject.SetActive(true);
            GetComponent<Image>().color = new Color(0, 0, 0);
            StartCoroutine(DisableText());
        }

    }
    
}
