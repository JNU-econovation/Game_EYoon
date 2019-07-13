using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public Image HPImage; //캐릭터 위의 hp바
    public float hp;//캐릭터의 현재 체력
    public float maxHp; //캐릭터의 최대 체력

    void Update()
    {
        if (hp >= maxHp)
            hp = maxHp;
        else if (hp <= 0.0f)
            hp = 0.0f;
        HPImage.fillAmount = hp / maxHp;       
    }

    public void IncreaseHP(float increase)
    {
        hp += increase;
    }

    public void DecreaseHP(float decrease)
    {
        hp -= decrease;
    }

}

