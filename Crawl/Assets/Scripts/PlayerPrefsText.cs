using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerPrefsText : MonoBehaviour
{
    [SerializeField] string Key;
    [SerializeField] int value;
    [SerializeField] string statname;
    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt(Key,value);
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Text>().text = statname + PlayerPrefs.GetInt(Key);
    }
}
