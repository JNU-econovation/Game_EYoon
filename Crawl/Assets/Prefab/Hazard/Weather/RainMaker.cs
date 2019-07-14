using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainMaker : MonoBehaviour
{
    GameObject player;
    public GameObject service;

    public void SpeedUpDecreasingStamina()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        player.GetComponent<Ability>().staminaDecreaseSpeed = 6;
    }

    public void RecoverStaminaSpeed()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        player.GetComponent<Ability>().staminaDecreaseSpeed = 2;
    }

   
}
