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
    float maxHeight;
    bool isComplete = false;
    private void Start()
    {
        service = GameObject.FindGameObjectWithTag("Service");
        heightText = GetComponent<Text>();
        player = service.GetComponent<LevelManager>().player;
        StartCoroutine(HeightUI());
    }

    IEnumerator HeightUI()
    {
        while (true)
        {
            float height = player.transform.position.y / 10;
           
            heightText.text = ((int)height).ToString() + "m";
            yield return null;
        }
       
    }
}
