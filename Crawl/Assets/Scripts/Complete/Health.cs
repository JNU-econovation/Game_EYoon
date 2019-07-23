using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public Image HPImage; //캐릭터 위의 hp바
    public Text damagedAmount;
    public float hp;//캐릭터의 현재 체력
    public float maxHp; //캐릭터의 최대 체력
    public float stamina;
    public float maxStamina = 100.0f;
    public float staminaDecreaseSpeed;
    public float originalStaminaDecreaseSpeed;
    public float maxStaminaDecreaseSpeed;
    public float hpDecreaseSpeed;
    float armor;
    private void Start()
    {
        originalStaminaDecreaseSpeed = staminaDecreaseSpeed;
    }
    void Update()
    { 
        if (hp >= maxHp)
            hp = maxHp;
        else if (hp <= 0.0f)
        {
            hp = 0.0f;
            Manager.Instance.Gameover();
        }

        stamina -= Time.deltaTime * staminaDecreaseSpeed;
        if (stamina <= 0)
        {
            stamina = 0;
            GetComponent<Health>().hp -= Time.deltaTime * hpDecreaseSpeed;
        }
        HPImage.fillAmount = hp / maxHp;       
    }

    public void IncreaseHP(float increase)
    {
        hp += increase;
    }

    public void DecreaseHP(float decrease)
    {
        float armor = GetComponent<Ability>().armor;
        float maxArmor = GetComponent<Ability>().maxArmor;

        decrease = decrease * (1 - armor / maxArmor);
        hp -= decrease;
        if (hp <= 0)
            Manager.Instance.Gameover();
      //  damagedAmount.text = decrease.ToString();
    }

    public void IncreaseStamina(float increase)
    {
        stamina += increase;
        if (stamina >= maxStamina)
        {
            stamina = maxStamina;
        }
    }

    public void DecreaseStamina(float decrease)
    {
        stamina -= decrease;
        if (stamina < 1)
        {
            stamina = 0;
        }
    }

    public void DecreaseStaminaSpeed(int n)
    {
        maxStaminaDecreaseSpeed -= n;
        if(maxStaminaDecreaseSpeed <= originalStaminaDecreaseSpeed)
        {
            maxStaminaDecreaseSpeed = originalStaminaDecreaseSpeed;
        }
    }
   
}

