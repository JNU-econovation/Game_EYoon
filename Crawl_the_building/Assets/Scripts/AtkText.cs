using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AtkText : MonoBehaviour
{
    [SerializeField] Abilitymanager Abilitymanager;
    int statvalue;


    void Update()
    {

        statvalue = Abilitymanager.Character.GetComponent<BasicCharacter>().Atk;
        GetComponent<Text>().text = "Atk: " + statvalue.ToString();

    }

}
