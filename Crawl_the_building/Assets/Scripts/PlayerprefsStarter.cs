using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerprefsStarter : MonoBehaviour
{
    string[] Keys = {"Basic_Atk", "Basic_Def", "Basic_Dex","Basic_Mag","Character1_Atk","Character1_Def", "Character1_Dex", "Character1_Mag" };
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
                else if (i == 3)
                {
                    PlayerPrefs.SetInt(Keys[i], 30);
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
