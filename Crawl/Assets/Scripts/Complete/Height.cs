using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Height : Singleton<Height>
{
    Text heightText;
    GameObject player;
    public GameObject service;
    public float ypos;
    public float height;
    public float maxHeight;
    private void Start()
    {
        heightText = GetComponent<Text>();
        player = service.GetComponent<LevelManager>().player;
    }
    void Update()
    {
        height = player.transform.position.y / 10;
        if(height >= 500)
        {
            Manager.Instance.StopPlayer();
            Manager.Instance.GameComplete();
            
        }
        service.GetComponent<Manager>().height = ypos;
        heightText.text = ((int)height).ToString() + "m";

    }
}
