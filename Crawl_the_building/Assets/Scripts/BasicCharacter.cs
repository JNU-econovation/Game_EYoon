using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicCharacter : MonoBehaviour
{
    public int Atk;
    public int Def;
    public int Dex;
    public Abilitymanager Abilitymanager;

    private void OnEnable()
    {
        Abilitymanager.Character = gameObject;
    }
    void Update()
    {
      
        Atk = PlayerPrefs.GetInt("Basic_Atk");
        Def = PlayerPrefs.GetInt("Basic_Def");
        Dex = PlayerPrefs.GetInt("Basic_Dex");
    }
 
}
