using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    //public Transform target;
    public Image HPImage;
    public int hp;//캐릭터의 현재 체력
    public int maxHp; //캐릭터의 최대 체력
    float fillAmount;
    void Update()
    {
        if (hp >= maxHp)
            hp = maxHp;
        else if (hp <= 0)
            hp = 0;
        HPImage.fillAmount = (float)hp / maxHp;       
    }
  
}

