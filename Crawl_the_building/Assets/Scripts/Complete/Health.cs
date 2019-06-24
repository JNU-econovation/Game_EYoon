using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    //public Transform target;
    Image HPImage;
    public float hp;//캐릭터의 현재 체력
    public float maxHp; //캐릭터의 풀피

    void Start()
    {
        HPImage = GetComponentInChildren<Image>();
    }
    void Update()
    {
        if (hp >= maxHp)
            hp = maxHp;
        HPImage.fillAmount = hp / maxHp;
    }
}

