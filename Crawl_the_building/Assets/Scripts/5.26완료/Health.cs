using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    //public Transform target;
    Image imageHP;
    public Text hpUI;
    public float hp;//캐릭터의 현재 체력
    public float maxHp; //캐릭터의 풀피

    private void Start()
    {
        imageHP = GetComponentInChildren<Image>();
    }
    private void Update()
    {
        hpUI.text = hp.ToString();
        imageHP.fillAmount = hp / maxHp;
    }
}

