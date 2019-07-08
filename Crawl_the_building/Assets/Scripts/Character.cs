using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public int Atk;
    public int Def;
    public int Dex;
    public int AtkUPCount;
    public int DefUpCount;
    public int DexUpCount;
    string characterName;
    public Abilitymanager Abilitymanager;
    private void Start()
    {
        characterName = gameObject.name;   
    }
    private void OnEnable()
    {
        Abilitymanager.Character = gameObject;
    }
    void Update()
    {
      
        Atk = PlayerPrefs.GetInt(characterName + "Atk");
        Def = PlayerPrefs.GetInt(characterName + "Def");
        Dex = PlayerPrefs.GetInt(characterName + "Dex");
    }
 
}
