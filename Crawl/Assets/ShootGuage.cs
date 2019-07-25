using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShootGuage : MonoBehaviour
{
    float shootingGauge = 100.0f;
    float maxShootingGauge = 100.0f;
    Image image;
    private void Start()
    {
        image = GetComponent<Image>();
    }
    private void Update()
    {
        bool isClicked = AttackButton.Instance.isClicked;
        if (shootingGauge <= 0)
        {
            shootingGauge = 0;
            AttackButton.Instance.isClicked = false;          
            AutoAttack.Instance.StopAttack(isClicked);
        }

        if (isClicked == false)
        {
            shootingGauge += Time.deltaTime * 5;
            if (shootingGauge >= maxShootingGauge)
                shootingGauge = maxShootingGauge;
        }
        else
        {
            shootingGauge -= Time.deltaTime * 5;
        }

        image.fillAmount = shootingGauge / maxShootingGauge;      
    }
}
