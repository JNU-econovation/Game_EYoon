using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stamina : MonoBehaviour
{
    public float stamina;
    float maxStamina = 100.0f;
    Image staminaImage;
    private void Start()
    {
        staminaImage = GetComponent<Image>();
    }
    private void Update()
    {
        stamina -= Time.deltaTime * 2;
        staminaImage.fillAmount = stamina / maxStamina;
    }
}
