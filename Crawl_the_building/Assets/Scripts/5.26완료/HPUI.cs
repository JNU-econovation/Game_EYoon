using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPUI : MonoBehaviour
{
    Text hpValue; //총알 개수
    public GameObject player;
    Image heart;
    float hp;
    float maxHp;

    private void Start()
    {
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
