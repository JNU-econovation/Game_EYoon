using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class AttackButton : MonoBehaviour
{
    float shootingGauge = 100;
    float maxShootingGauge = 100;
    Image image;
    bool isClicked = false;
    [SerializeField] GameObject shoot;
    private void Start()
    {
        image = GetComponent<Image>();
    }
            
    
    private void Update()
    {
        if (shootingGauge <= 0)
        {
            shootingGauge = 0;
            isClicked = false;
            shoot.GetComponent<AudioSource>().enabled = false;
            AutoAttack.Instance.StopAttack(isClicked);
        }           

        if (isClicked == false)
        {
            shootingGauge += Time.deltaTime * 3;
            if (shootingGauge >= maxShootingGauge)
                shootingGauge = maxShootingGauge;
        }
        else
        {
            shootingGauge -= Time.deltaTime * 3;
        }
                   
        image.fillAmount = shootingGauge / maxShootingGauge;
    }       

    public void Attack(GameObject shoot)
    {
        if(isClicked == false)
        {
            isClicked = true;
            shoot.GetComponent<AudioSource>().Play();
            AutoAttack.Instance.StartAttack(isClicked);
        }
        else
        {
            isClicked = false;
            shoot.GetComponent<AudioSource>().Stop();
            AutoAttack.Instance.StopAttack(isClicked);
        }
    }
}
