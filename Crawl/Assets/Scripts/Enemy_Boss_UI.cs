using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy_Boss_UI : MonoBehaviour
{
    [SerializeField] Image hpImage;
    [SerializeField] Text hpText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {
        hpText.text = GetComponent<Enemy_Ability>().GetHp().ToString();
        hpImage.fillAmount = GetComponent<Enemy_Ability>().GetHp() / GetComponent<Enemy_Ability>().GetMaxHp();
    }
}
