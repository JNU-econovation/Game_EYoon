using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    //public Transform target;
    public Image HP;
    public Transform headUp;
    public Text hpUI;
    [SerializeField] float fullHp;//캐릭터의 현재 체력
    [SerializeField] float maxHp; //캐릭터의 풀피


    private void Update()
    {
        hpUI.text = fullHp.ToString();
        HP.fillAmount = fullHp * 1 / maxHp;

       
    }
    void Awake()
    {
        HP.transform.position = headUp.position;
    }
}


