using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Height : MonoBehaviour
{
    Text heightText;
    GameObject service;
    GameObject player;
    public GameObject scoreUI;
    float height = 0;
    float startHeight;
    bool isComplete = false;
    private void Start()
    {
        service = GameObject.FindGameObjectWithTag("Service");
        heightText = GetComponent<Text>();
        player = service.GetComponent<LevelManager>().player;
        startHeight = player.transform.position.y;
        StartCoroutine(HeightUI());
    }

    IEnumerator HeightUI()
    {
        while (true)
        {
            height = (player.transform.position.y - startHeight) / 20;
            heightText.text = ((int)height).ToString() + "m";
            yield return null;
        }
       
    }
}
