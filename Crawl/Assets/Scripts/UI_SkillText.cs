using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UI_SkillText : MonoBehaviour
{
    Text skillText;
    private void Awake()
    {
        skillText = GetComponent<Text>();
    }
    private void OnEnable()
    {
        skillText.text = "";
    }
    public void SetText(string str)
    {
        skillText.text = str;
    }
}
