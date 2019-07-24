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
    static float umbrellalevel;
    public float originalStaminaDecreaseSpeed;
    public float maxStaminaDecreaseSpeed;
    static float rainStaminaDecreaseSpeed = 6.0f;
    public float centerStaminaDecreaseSpeed;
    public float hpDecreaseSpeed;
    public GameObject hitEffect;

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
        bool isCenter = GetComponent<PlayerMove>().isCenter;
        bool isRain = RainState.Instance.isRain;

        if(isRain && isCenter)
        {
            staminaDecreaseSpeed = (rainStaminaDecreaseSpeed + centerStaminaDecreaseSpeed);
            
        }
        else if(isRain && isCenter == false)
            staminaDecreaseSpeed = rainStaminaDecreaseSpeed;
        else if(isRain == false && isCenter)
            staminaDecreaseSpeed = centerStaminaDecreaseSpeed;
        else staminaDecreaseSpeed = originalStaminaDecreaseSpeed;

        stamina -= Time.deltaTime * staminaDecreaseSpeed;

        if (stamina <= 0)
        {
            stamina = 0;
            GetComponent<Health>().hp -= Time.deltaTime * hpDecreaseSpeed;
            Blood.Instance.gameObject.SetActive(true);
        }
        else
        {
            Blood.Instance.gameObject.SetActive(false);
        }
        HPImage.fillAmount = hp / maxHp;
        print(staminaDecreaseSpeed);
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
        GameObject temp = Instantiate(hitEffect);
        temp.transform.position = transform.position;
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

    public void UmbrellaCount(float n)
    {
        rainStaminaDecreaseSpeed -= n;
        if (rainStaminaDecreaseSpeed <= originalStaminaDecreaseSpeed)
            rainStaminaDecreaseSpeed = originalStaminaDecreaseSpeed;
    }
    
   
}

