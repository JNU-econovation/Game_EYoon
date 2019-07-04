using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DexText : MonoBehaviour
{
    [SerializeField] Abilitymanager Abilitymanager;
    int statvalue;
    // Start is called before the first frame update


    void Update()
    {
        statvalue = Abilitymanager.Character.GetComponent<BasicCharacter>().Dex;
        GetComponent<Text>().text = "Dex: " + statvalue.ToString();
    }

}
