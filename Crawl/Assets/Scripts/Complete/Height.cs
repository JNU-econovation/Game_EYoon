using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Height : MonoBehaviour
{
    Text heightText;
    public GameObject service;
    private void Start()
    {
        heightText = GetComponent<Text>();
    }

    void Update()
    {
        float height = service.GetComponent<LevelManager>().height;
        heightText.text = ((int)height).ToString() + "m";
    }
}
