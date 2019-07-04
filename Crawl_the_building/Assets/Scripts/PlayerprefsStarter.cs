using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerprefsStarter : MonoBehaviour
{
    string[] Keys = {"Basic_Atk", "Basic_Def", "Basic_Dex" };
    private void Awake()
    {
        for (int i = 0; i < Keys.Length;  i++)
        {
            if (PlayerPrefs.GetInt(Keys[i]) == 0);
            {
                if (i == 0)
                {
                    PlayerPrefs.SetInt(Keys[i], 20);
                }
                else
                {
                    PlayerPrefs.SetInt(Keys[i], 10);
                }
            }
        }

        PlayerPrefs.SetInt("Gold", 3847);
    }

}
