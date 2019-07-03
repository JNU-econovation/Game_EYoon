using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AtkText : MonoBehaviour
{
    private void Start()
    {
        PlayerPrefs.SetInt("Atk", 20);
    }
    private void Update()
    {
        GetComponent<Text>().text = "Atk: " + PlayerPrefs.GetInt("Atk");
    }
}
