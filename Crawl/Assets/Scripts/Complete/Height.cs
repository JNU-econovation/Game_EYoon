using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Height : MonoBehaviour
{
    Text heightText;
    public GameObject service;
    GameObject player;
    public GameObject scoreUI;
    float maxHeight;
    private void Start()
    {
        heightText = GetComponent<Text>();
        maxHeight = service.GetComponent<LevelManager>().maxHeight;
        player = service.GetComponent<LevelManager>().player;
        StartCoroutine(HeightUI());
    }

    IEnumerator HeightUI()
    {
        while (true)
        {
            float height = service.GetComponent<LevelManager>().height;

            if (height >= maxHeight)
            {
                height = maxHeight;                            
                Manager.Instance.GameComplete();
                yield return new WaitForSeconds(2.0f);
                scoreUI.gameObject.SetActive(true);
                Time.timeScale = 0;
            }
            heightText.text = ((int)height).ToString() + "m";
            yield return null;
        }
       
    }
}
