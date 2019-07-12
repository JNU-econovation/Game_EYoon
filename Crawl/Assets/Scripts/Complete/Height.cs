using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Height : MonoBehaviour
{
    Text heightText;
    GameObject player;
    public GameObject service;
    private void Start()
    {
        heightText = GetComponent<Text>();
        player = service.GetComponent<LevelManager>().player;
    }
    void Update()
    {
        float ypos = player.transform.position.y / 10;
        heightText.text = ((int)ypos).ToString() + "m";

    }
}
