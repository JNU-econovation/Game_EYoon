using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPUI : MonoBehaviour
{
    public Text hpValue; 
    GameObject player;
    GameObject service;
    Image heart;
    float hp;
    float maxHp;

    private void Start()
    {
        service = GameObject.FindGameObjectWithTag("Service");
        player = service.GetComponent<LevelManager>().player;
        heart = GetComponent<Image>();       
    }

    void Update()
    {
        hp = player.GetComponent<Health>().hp;
        maxHp = player.GetComponent<Health>().maxHp;
        hpValue.text = ((int)(player.GetComponent<Health>().hp)).ToString();
        heart.fillAmount = hp / maxHp;
    }
}
