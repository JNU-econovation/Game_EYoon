using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class FireExtinguish : MonoBehaviour
{
    public GameObject service;
    GameObject player;
    public GameObject fire;
    private void Start()
    {
        player = service.GetComponent<LevelManager>().player;
    }

    public void FireOff()
    {
        if(GetComponent<FireExInventory>().fireExCount > 0)
        {
            foreach (var fire in service.GetComponent<LevelManager>().fireList)
            {
                Destroy(fire);
            }
            int fireExCount = --player.GetComponent<Ability>().fireExCount;
            GetComponent<FireExInventory>().fireExCount = fireExCount;
            GetComponentInChildren<Text>().text = fireExCount.ToString();
        }

        if (GetComponent<FireExInventory>().fireExCount == 0)
            GetComponent<Image>().sprite = null;
    }
  
}
