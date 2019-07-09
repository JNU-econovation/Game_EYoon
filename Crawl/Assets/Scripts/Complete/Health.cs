using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    //public Transform target;
    Image HPImage;
    public int hp;//캐릭터의 현재 체력
    public int maxHp; //캐릭터의 풀피

    void Awake()
    {
        HPImage = GetComponentInChildren<Image>();
    }
    void Update()
    {
        if (hp >= maxHp)
            hp = maxHp;
        else if (hp <= 0)
            hp = 0;
        HPImage.fillAmount = hp / maxHp;
    }
}

