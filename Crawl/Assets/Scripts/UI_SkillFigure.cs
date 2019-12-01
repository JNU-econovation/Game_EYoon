using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UI_SkillFigure : MonoBehaviour
{
    Text skillFigure;
    private void Awake()
    {
        skillFigure = GetComponent<Text>();
    }
    private void OnEnable()
    {
        skillFigure.text = "";
    }
    public void SetText(string str)
    {
        skillFigure.text = str;
    }
}
