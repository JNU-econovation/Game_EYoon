using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DefText : MonoBehaviour
{
    // Start is called before the first frame update
    private void Start()
    {
        PlayerPrefs.SetInt("Def", 20);
    }
    private void Update()
    {
        GetComponent<Text>().text = "Def: " + PlayerPrefs.GetInt("Def");
    }
}
