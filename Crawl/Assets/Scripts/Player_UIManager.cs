using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Player_UIManager : MonoBehaviour
{
    [SerializeField] Text hpText;
    [SerializeField] Image hpImage;
    [SerializeField] Image staminaImage;
    void Start()
    {
        
    }
  
    void Update()
    {
        hpText.text = ((int)Player_AbilityManager.Instance.GetHP()).ToString();       
        hpImage.fillAmount = Player_AbilityManager.Instance.GetHP() / Player_AbilityManager.Instance.GetMaxHP();
        staminaImage.fillAmount = Player_AbilityManager.Instance.GetStamina() / Player_AbilityManager.Instance.GetMaxStamina();
    }
}
