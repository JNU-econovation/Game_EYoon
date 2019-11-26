using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Player_UI_HPText : MonoBehaviour
{
    Text hpText;
    private void Start()
    {
        hpText = GetComponent<Text>();
    }
    void Update()
    {
        float hp = Player_AbilityManager.Instance.GetHP();
        hpText.text = ((int)(hp)).ToString();
    }
}
