using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_HPManager : MonoBehaviour
{
    float HP;
    float stamina;
    public float decreaseStaminaSpeed;
    void Start()
    {
        
    }
  
    void Update()
    {
        stamina = Player_AbilityManager.Instance.GetStamina();
        Player_AbilityManager.Instance.DecreseStamina(decreaseStaminaSpeed * Time.deltaTime / 3);
        if (stamina == 0)
            Player_AbilityManager.Instance.DecreaseHP(0.01f);
    }
}
