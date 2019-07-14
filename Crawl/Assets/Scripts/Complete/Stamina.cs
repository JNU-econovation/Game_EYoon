using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stamina : MonoBehaviour
{
    public float decreaseSpeed;
    public float stamina;
    GameObject player;
    public GameObject service;

    float maxStamina = 100.0f;
    Image staminaImage;
    private void Start()
    {
        staminaImage = GetComponent<Image>();
        player = service.GetComponent<LevelManager>().player;
    }
    private void Update()
    {
        stamina = player.GetComponent<Ability>().stamina;
        staminaImage.fillAmount = stamina / maxStamina;
    }
}
