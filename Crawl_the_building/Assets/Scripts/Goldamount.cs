using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Goldamount : MonoBehaviour
{
    int Gold;
    private void Start()
    {
        PlayerPrefs.SetInt("Gold",324 );
    }
    void Update()
    {
        Gold = PlayerPrefs.GetInt("Gold");
        GetComponent<Text>().text = Gold.ToString();
    }
}
