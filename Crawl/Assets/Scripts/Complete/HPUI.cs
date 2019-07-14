using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPUI : MonoBehaviour
{
    Text hpValue; 
    GameObject player;
    public GameObject service;
    Image heart;
    float hp;
    float maxHp;

    private void Start()
    {
        player = service.GetComponent<LevelManager>().player;
        heart = GetComponentInParent<Image>();
        hpValue = GetComponent<Text>();
       
    }

    void Update()
    {
        hp = player.GetComponent<Health>().hp;
        maxHp = player.GetComponent<Health>().maxHp;
        hpValue.text = ((int)(player.GetComponent<Health>().hp)).ToString() + "/100";
        heart.fillAmount = hp / maxHp;
    }
}
