using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPUI : MonoBehaviour
{
    Text hpValue; //총알 개수
    GameObject player;
    public GameObject service;
    Image heart;
    float hp;
    float maxHp;

    private void Start()
    {
        player = service.GetComponent<LevelManager>().player;
        heart = GetComponent<Image>();
        hpValue = GetComponentInChildren<Text>();
       // hp = player.GetComponent<Health>().hp;
       // maxHp = player.GetComponent<Health>().maxHp;
    }

    void Update()
    {
        hp = player.GetComponent<Health>().hp;
        maxHp = player.GetComponent<Health>().maxHp;
        hpValue.text = hp.ToString();
        heart.fillAmount = hp / maxHp;
    }
}
