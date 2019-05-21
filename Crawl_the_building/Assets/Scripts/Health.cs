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
    [SerializeField] float hp;//캐릭터의 현재 체력
    [SerializeField] float maxHp; //캐릭터의 풀피

    private void Start()
    {
        hp = maxHp;
    }
    private void Update()
    {
        hpUI.text = hp.ToString();
        HP.fillAmount = hp * 1 / maxHp;

       
    }
    void Awake()
    {
        HP.transform.position = headUp.position;
    }
}


