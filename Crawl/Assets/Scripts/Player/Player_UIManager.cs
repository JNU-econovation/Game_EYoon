using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Player_UIManager : Singleton<Player_UIManager>
{
    [SerializeField] Text hpText;
    [SerializeField] Image hpImage;
    [SerializeField] Image staminaImage;
    public GameObject player_Damage;
    public Transform hudPos;

    void Update()
    {
        hpText.text = ((int)Player_AbilityManager.Instance.GetHP()).ToString();       
        hpImage.fillAmount = Player_AbilityManager.Instance.GetHP() / Player_AbilityManager.Instance.GetMaxHP();
        staminaImage.fillAmount = Player_AbilityManager.Instance.GetStamina() / Player_AbilityManager.Instance.GetMaxStamina();
    }

    public void TakeDamage(float damage)
    {
        GameObject hudText = Instantiate(player_Damage);
        hudText.transform.position = hudPos.position;
        hudText.GetComponent<Player_DamageText>().damage = damage;
    }
}
