using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stamina : MonoBehaviour
{
    public float stamina;
    GameObject player;
    public GameObject service;

    float maxStamina;
    Image staminaImage;
    private void Start()
    {
        staminaImage = GetComponent<Image>();
        player = service.GetComponent<LevelManager>().player;
    }
    private void Update()
    {
        stamina = player.GetComponent<Health>().stamina;
        maxStamina = player.GetComponent<Health>().maxStamina;
        staminaImage.fillAmount = stamina / maxStamina;
    }
}
