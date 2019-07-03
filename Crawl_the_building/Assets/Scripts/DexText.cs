using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DexText : MonoBehaviour
{
    // Start is called before the first frame update
    private void Start()
    {
        PlayerPrefs.SetInt("Dex", 20);
    }
    private void Update()
    {
        GetComponent<Text>().text = "Dex: " + PlayerPrefs.GetInt("Dex");
    }
}
