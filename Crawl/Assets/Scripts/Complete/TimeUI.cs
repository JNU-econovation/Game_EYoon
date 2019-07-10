using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TimeUI : MonoBehaviour
{
    float time = 0.0f;
    float minute = 0.0f;
    float second = 0.0f;
    Text timeText;
    private void Start()
    {
        timeText = GetComponent<Text>();
    }

    void Update()
    {
        string str = "";
        string minuteStr = Mathf.Round(minute).ToString();
        string secondStr = Mathf.Round(second).ToString();
        second += Time.deltaTime;
        if (second > 59.0f)
        {            
            second -= 59.0f;
            minute++;
        }
        if (Mathf.Round(minute) <= 9)
        {
            minuteStr = "0" + Mathf.Round(minute);
        }
        if(Mathf.Round(second) <= 9)
        {
            secondStr = "0" + Mathf.Round(second);
        }
     
            
        str = minuteStr + ":"+ secondStr;      
        timeText.text = str;
    }
}
