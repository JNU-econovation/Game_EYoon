using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pausebutton : MonoBehaviour
{
    public void PauseGame()
    {
        Time.timeScale = 0;
        Time.fixedDeltaTime = 0;
        print(231);
    }
 
}
