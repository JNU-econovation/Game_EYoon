using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DefText : MonoBehaviour
{
    [SerializeField] Abilitymanager Abilitymanager;
    int statvalue;
    // Start is called before the first frame update


    void Update()
    {
        
        statvalue = Abilitymanager.Character.GetComponent<BasicCharacter>().Def;
        GetComponent<Text>().text = "Def: " + statvalue.ToString();
        
        

    }


}
