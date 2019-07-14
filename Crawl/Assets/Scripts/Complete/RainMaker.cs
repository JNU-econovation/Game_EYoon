using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainMaker : MonoBehaviour
{
    GameObject player;
    static float maxSpeed = 6.0f;
    float startMaxSpeed;
    private void Start()
    {
        startMaxSpeed = maxSpeed;
    }
    public void SpeedUpDecreasingStamina()
    {       
        player = GameObject.FindGameObjectWithTag("Player");
        player.GetComponent<Health>().staminaDecreaseSpeed = maxSpeed;
    }

    public void SpeedDownStaminaSpeed()
    {
        maxSpeed -= 1;
    }

    public void RecoverStaminaSpeed()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        player.GetComponent<Health>().staminaDecreaseSpeed = player.GetComponent<Health>().originalStaminaDecreaseSpeed;
        
    }
   
}
