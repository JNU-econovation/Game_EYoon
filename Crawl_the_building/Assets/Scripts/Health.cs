using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    //public Transform target;
    public Image HP;
    public Text hpUI;
    public float hp;//캐릭터의 현재 체력
    float maxHp; //캐릭터의 풀피

    private void Start()
    {
        hp = maxHp;
    }
    private void Update()
    {
        hpUI.text = hp.ToString();
        HP.fillAmount = hp / maxHp;
    }
}

