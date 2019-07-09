using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Goldamount : MonoBehaviour
{
    int Gold;

    void Update()
    {
        Gold = PlayerPrefs.GetInt("Gold");
        GetComponent<Text>().text = Gold.ToString();
    }
}
