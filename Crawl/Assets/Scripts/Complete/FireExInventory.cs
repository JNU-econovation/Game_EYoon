using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FireExInventory : Singleton<FireExInventory>
{
    int fireExCount = 0;
    Image image;
    Text countText;
    public GameObject service;
    GameObject player;
    float disableTime = 0.5f;
    public GameObject fireExItem;
    private void Start()
    {       
        countText = GetComponentInChildren<Text>();
        countText.gameObject.SetActive(false);
        image = GetComponentInChildren<Image>();
    }    

    public void ChangeCount(int count)
    {
        fireExCount = count;
        countText.text = fireExCount.ToString();
        countText.gameObject.SetActive(true);
        image.gameObject.SetActive(false);
        StartCoroutine(DisableText());
    }

    IEnumerator DisableText()
    {
        yield return new WaitForSeconds(disableTime);
        countText.gameObject.SetActive(false);
        image.gameObject.SetActive(true);
    }

    public void FireOff()
    {
        if (fireExCount > 0)
        {
            foreach (var fire in service.GetComponent<LevelManager>().fireList)
            {
                Destroy(fire);
            }
            fireExItem.GetComponent<FireExtinguisherItem>().DisChargeFireExCount();
            int count = fireExItem.GetComponent<FireExtinguisherItem>().GetFireExCount();
            ChangeCount(count);
        }

    }
    
}
